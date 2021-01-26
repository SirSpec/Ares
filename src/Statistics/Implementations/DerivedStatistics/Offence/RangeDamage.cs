using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public class RangeDamage : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;
        private readonly Dexterity dexterity;

        public string Name { get; } = "Range Damage";
        public int BaseValue => baseValue * dexterity.Value;
        public IList<IEnhancement> Enhancements { get; }

        public int Value => BaseValue + EnhancementsValue;

        public RangeDamage(Dexterity dexterity) : this(Minimum, dexterity, new List<IEnhancement>())
        {
        }

        public RangeDamage(int baseValue, Dexterity dexterity, IList<IEnhancement> enhancements)
        {
            SetBaseValue(baseValue);
            this.dexterity = dexterity;
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