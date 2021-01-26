using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public class MeleeDamage : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;
        private readonly Strength strength;

        public string Name { get; } = "Melee Damage";
        public int BaseValue => baseValue * strength.Value;
        public IList<IEnhancement> Enhancements { get; }

        public int Value => BaseValue + EnhancementsValue;

        public MeleeDamage(Strength strength) : this(Minimum, strength, new List<IEnhancement>())
        {
        }

        public MeleeDamage(int baseValue, Strength strength, IList<IEnhancement> enhancements)
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