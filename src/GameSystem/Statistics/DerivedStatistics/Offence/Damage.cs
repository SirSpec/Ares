using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;
using Attribute = Ares.GameSystem.Statistics.PrimaryStatistics.Attributes.Attribute;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public abstract class Damage : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;
        private readonly Attribute attribute;

        public abstract string Name { get; }
        public int BaseValue => baseValue * attribute.Value;
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public int Value => BaseValue + EnhancementsValue;

        public Damage(Attribute attribute) : this(Minimum, attribute, new List<IEnhancement<IStatistic>>())
        {
        }

        public Damage(int baseValue, Attribute attribute, IList<IEnhancement<IStatistic>> enhancements)
        {
            SetBaseValue(baseValue);
            this.attribute = attribute;
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