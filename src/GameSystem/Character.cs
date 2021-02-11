using System;
using System.Linq;
using Ares.Inventory;
using Ares.Progression;
using Ares.Statistics;
using Ares.GameSystem.Statistics.DerivedStatistics.Offence;
using Ares.GameSystem.Statistics.PrimaryStatistics.Defence;
using Ares.GameSystem.Weapons;
using Ares.GameSystem.Defence;
using Ares.Spells;
using Ares.Spells.Effects;
using System.Collections.Generic;
using Ares.GameSystem.Effects;

namespace Ares.GameSystem
{
    public class Character : ITarget, IDamageDealer, ICaster
    {
        public string Name { get; }
        public int SkillPoints { get; private set; }
        public StatisticsSet StatisticsSet { get; }
        public InventorySet Inventory { get; }
        public SpellBook SpellBook { get; }
        public ExperiencePool Experience { get; }
        public EnergyPool HealthPool { get; }
        public EnergyPool ManaPool { get; }
        public IList<IBuff> Buffs { get; }

        public Character(
            string name,
            int skillPoints,
            StatisticsSet statisticsSet,
            InventorySet inventory,
            SpellBook spellBook,
            ExperiencePool experience,
            EnergyPool healthPool,
            EnergyPool manaPool,
            IList<IBuff> buffs)
        {
            Name = name;
            SkillPoints = skillPoints;
            StatisticsSet = statisticsSet;

            Inventory = inventory;
            SpellBook = spellBook;
            Inventory.Equipment.Equiped += OnEquiped;
            Inventory.Equipment.Unequiped += OnUnequiped;

            Experience = experience;
            Experience.LeveledUp += OnLeveledUpHandler;

            HealthPool = healthPool;
            ManaPool = manaPool;
            Buffs = buffs;
        }

        public bool IsDead => HealthPool.Current == 0;

        public bool IsUnarmed =>
            Inventory.Equipment.Slots
                .Single(slot => slot.SlotType.Equals(SlotType.MainHand))
                .IsEmpty;

        public DamageDealt Attack() =>
            IsUnarmed
                ? new DamageDealt(StatisticsSet.GetStatistic<MeleeDamage>().Value, DamageType.Melee)
                : new DamageDealt(
                    EquipedWeapon.Damage.Type switch
                    {
                        DamageType.Melee => StatisticsSet.GetStatistic<MeleeDamage>().Value,
                        DamageType.Range => StatisticsSet.GetStatistic<RangeDamage>().Value,
                        DamageType.Fire => StatisticsSet.GetStatistic<FireDamage>().Value,
                        DamageType.Ice => StatisticsSet.GetStatistic<IceDamage>().Value,
                        DamageType.Lightning => StatisticsSet.GetStatistic<LightningDamage>().Value,
                        _ => throw new ArgumentException($"{nameof(DamageType)} is invalid: {EquipedWeapon.Damage.Type}.")
                    }, EquipedWeapon.Damage.Type);

        public void TakeDamage(DamageDealt damage)
        {
            var reducedDamage = damage.Type switch
            {
                DamageType.Melee => damage.Value - StatisticsSet.GetStatistic<Armor>().Value,
                DamageType.Range => damage.Value - StatisticsSet.GetStatistic<Armor>().Value,
                DamageType.Fire => damage.Value - damage.Value * StatisticsSet.GetStatistic<FireResistance>().Value / 100,
                DamageType.Ice => damage.Value - damage.Value * StatisticsSet.GetStatistic<IceResistance>().Value / 100,
                DamageType.Lightning => damage.Value - damage.Value * StatisticsSet.GetStatistic<LightningResistance>().Value / 100,
                _ => throw new ArgumentException($"{nameof(DamageType)} is invalid: {damage.Type}.")
            };

            HealthPool.Decrease(reducedDamage > 0 ? reducedDamage : 1);
        }

        public IEffect Cast(Spell spell)
        {
            if (SpellBook.Contains(spell) && ManaPool.Current >= spell.Cost)
            {
                ManaPool.Decrease(spell.Cost);
                return spell.Effect;
            }
            else throw new ArgumentException($"Cannot cast {nameof(spell)}:{spell.Name}.");
        }

        public void AddBuff(IBuff buff)
        {
            if (Buffs.Contains(buff) is false)
            {
                Buffs.Add(buff);
                StatisticsSet.Apply(buff.Enhancement);
            }
            else throw new ArgumentException($"{nameof(buff)}:{buff.Name} already added.");
        }

        public void RemoveBuff(IBuff buff)
        {
            if (Buffs.Contains(buff))
            {
                Buffs.Remove(buff);
                StatisticsSet.Remove(buff.Enhancement);
            }
            else throw new ArgumentException($"{nameof(buff)}:{buff.Name} is not added.");
        }

        private void OnLeveledUpHandler(object? _, Level level) =>
            SkillPoints += level.Value - Experience.Level.Value;

        private void OnUnequiped(object? _, UnequipedEventArgs args)
        {
            switch (args.UnequipedItem)
            {
                case Weapon:
                    StatisticsSet.GetStatistic<MeleeDamage>().SetBaseValue(0);
                    StatisticsSet.GetStatistic<RangeDamage>().SetBaseValue(0);
                    StatisticsSet.GetStatistic<FireDamage>().SetBaseValue(0);
                    StatisticsSet.GetStatistic<IceDamage>().SetBaseValue(0);
                    StatisticsSet.GetStatistic<LightningDamage>().SetBaseValue(0);
                    break;
                case BodyArmor:
                    StatisticsSet.GetStatistic<Armor>().SetBaseValue(SumOfBodyArmorValue);
                    break;
                default:
                    throw new ArgumentException($"Unequiped item has to be {nameof(Weapon)} or {nameof(BodyArmor)}.");
            }

            StatisticsSet.Remove(args.UnequipedItem.Enhancements.ToArray());
        }

        private void OnEquiped(object? _, EquipedEventArgs args)
        {
            switch (args.EquipedItem)
            {
                case Weapon newWeapon:
                    ModifyDamageStatistic(newWeapon);
                    break;
                case BodyArmor:
                    StatisticsSet.GetStatistic<Armor>().SetBaseValue(SumOfBodyArmorValue);
                    break;
                default:
                    throw new ArgumentException($"Equiped item has to be {nameof(Weapon)} or {nameof(BodyArmor)}.");
            }

            StatisticsSet.Apply(args.EquipedItem.Enhancements.ToArray());
        }

        private void ModifyDamageStatistic(Weapon newWeapon)
        {
            switch (newWeapon.Damage.Type)
            {
                case DamageType.Melee:
                    StatisticsSet.GetStatistic<MeleeDamage>().SetBaseValue(newWeapon.Damage.Value);
                    break;
                case DamageType.Range:
                    StatisticsSet.GetStatistic<RangeDamage>().SetBaseValue(newWeapon.Damage.Value);
                    break;
                case DamageType.Fire:
                    StatisticsSet.GetStatistic<FireDamage>().SetBaseValue(newWeapon.Damage.Value);
                    break;
                case DamageType.Ice:
                    StatisticsSet.GetStatistic<IceDamage>().SetBaseValue(newWeapon.Damage.Value);
                    break;
                case DamageType.Lightning:
                    StatisticsSet.GetStatistic<LightningDamage>().SetBaseValue(newWeapon.Damage.Value);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(DamageType)}:{newWeapon.Damage.Type}.");
            }
        }

        private int SumOfBodyArmorValue =>
            Inventory.Equipment.EquipedItems
                .Where(item => item is BodyArmor)
                .Select(item => (BodyArmor)item)
                .Sum(bodyArmor => bodyArmor.Armor.Value);

        private Weapon EquipedWeapon =>
            (Weapon)Inventory.Equipment.EquipedItems
                .Single(item => item is Weapon);
    }
}