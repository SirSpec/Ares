using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.Statistics;

namespace GameSystem.Weapons
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