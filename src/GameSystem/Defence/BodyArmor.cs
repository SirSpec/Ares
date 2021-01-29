using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.Statistics;

namespace GameSystem.Defence
{
    public class BodyArmor : IEquipable
    {
        public string Name { get; }
        public Enum SlotType { get; }
        public Weight Weight { get; }
        public ArmorValue Armor { get; }
        public IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }

        public BodyArmor(
            string name,
            SlotType slotType,
            Weight weight,
            ArmorValue armor,
            IEnumerable<IEnhancement<IStatistic>> enhancements)
        {
            Name = name;
            SlotType = slotType;
            Weight = weight;
            Armor = armor;
            Enhancements = enhancements;
        }
    }
}