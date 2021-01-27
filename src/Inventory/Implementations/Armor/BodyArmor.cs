using System;
using System.Collections.Generic;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;

namespace Ares.Inventory.Implementations.Armor
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
            Enum slotType,
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