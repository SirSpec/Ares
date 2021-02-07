using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.Statistics;

namespace Ares.GameSystem.Weapons
{
    public class Weapon : IEquipable
    {
        public string Name { get; }
        public Enum SlotType { get; }
        public Weight Weight { get; }
        public DamageDealt Damage { get; }
        public IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }

        public Weapon(
            string name,
            SlotType slotType,
            Weight weight,
            DamageDealt damage,
            IEnumerable<IEnhancement<IStatistic>> enhancements)
        {
            if (slotType is GameSystem.SlotType.MainHand or GameSystem.SlotType.OffHand)
            {
                Name = name;
                SlotType = slotType;
                Weight = weight;
                Damage = damage;
                Enhancements = enhancements;
            }
            else throw new ArgumentException(
                $"{nameof(slotType)} must be {GameSystem.SlotType.MainHand} or {GameSystem.SlotType.OffHand}.");
        }
    }
}