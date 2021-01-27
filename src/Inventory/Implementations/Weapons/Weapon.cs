using System;
using System.Collections.Generic;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;

namespace Ares.Inventory.Implementations.Weapons
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
            Enum slotType,
            Weight weight,
            DamageDealt damage,
            IEnumerable<IEnhancement<IStatistic>> enhancements)
        {
            Name = name;
            SlotType = slotType;
            Weight = weight;
            Damage = damage;
            Enhancements = enhancements;
        }
    }
}