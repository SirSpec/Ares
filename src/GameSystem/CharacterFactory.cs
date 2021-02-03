using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Inventory;
using Ares.Progression;
using Ares.Statistics;
using GameSystem.Statistics.DerivedStatistics.Energy;
using GameSystem.Statistics.DerivedStatistics.Offence;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using GameSystem.Statistics.PrimaryStatistics.Defence;

namespace GameSystem
{
    public class CharacterFactory
    {
        public Character NewCharacter(string name) =>
            new Character(
                name,
                skillPoints: 1,
                GetStatisticsSet(),
                GetInventorySet(),
                new ExperiencePool(points: 0),
                healthPool: new EnergyPool(total: 10),
                manaPool: new EnergyPool(total: 5));

        private StatisticsSet GetStatisticsSet()
        {
            var strength = new Strength();
            var dexterity = new Dexterity();
            var intelligence = new Intelligence();

            return new StatisticsSet(
                new List<IStatistic>
                {
                    strength,
                    dexterity,
                    intelligence,
                    new Armor(),
                    new FireResistance(),
                    new IceResistance(),
                    new LightningResistance(),
                    new Health(strength),
                    new Mana(intelligence),
                    new MeleeDamage(strength),
                    new RangeDamage(dexterity),
                    new FireDamage(intelligence),
                    new IceDamage(intelligence),
                    new LightningDamage(intelligence)
                }
            );
        }

        private InventorySet GetInventorySet() =>
            new InventorySet(
                new Equipment(GetSlots()),
                new Backpack(capacity: 10),
                new Weight(value: 10));

        private IList<Slot> GetSlots() =>
            Enum.GetValues<SlotType>()
                .Select(slotType => new Slot(slotType))
                .ToList();
    }
}