using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public abstract class ElementalDamage : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;
        private readonly Intelligence intelligence;

        public abstract string Name { get; }
        public int BaseValue => baseValue * intelligence.Value;
        public IList<IEnhancement> Enhancements { get; }

        public int Value => BaseValue + EnhancementsValue;

        public ElementalDamage(Intelligence intelligence) : this(Minimum, intelligence, new List<IEnhancement>())
        {
        }

        public ElementalDamage(int baseValue, Intelligence intelligence, IList<IEnhancement> enhancements)
        {
            SetBaseValue(baseValue);
            this.intelligence = intelligence;
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