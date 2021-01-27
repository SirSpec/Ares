using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;
using GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace GameSystem.Statistics.DerivedStatistics.Offence
{
    public class MeleeDamage : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;
        private readonly Strength strength;

        public string Name { get; } = "Melee Damage";
        public int BaseValue => baseValue * strength.Value;
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public int Value => BaseValue + EnhancementsValue;

        public MeleeDamage(Strength strength) : this(Minimum, strength, new List<IEnhancement<IStatistic>>())
        {
        }

        public MeleeDamage(int baseValue, Strength strength, IList<IEnhancement<IStatistic>> enhancements)
        {
            SetBaseValue(baseValue);
            this.strength = strength;
            Enhancements = enhancements;
        }

        public void SetBaseValue(int baseValue) =>
            this.baseValue = baseValue >= Minimum
                ? baseValue
                : throw new ArgumentException($"{nameof(baseValue)}:{baseValue} cannot be less than {Minimum}.");

        private int EnhancementsValue =>
            BaseValue > Minimum
                ? Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue))
                : Minimum;
    }
}