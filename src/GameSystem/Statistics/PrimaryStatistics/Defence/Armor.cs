using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;

namespace Ares.GameSystem.Statistics.PrimaryStatistics.Defence
{
    public class Armor : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;

        public string Name { get; } = "Armor";
        public int BaseValue => baseValue;
        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public Armor() : this(Minimum, new List<IEnhancement<IStatistic>>())
        {
        }

        public Armor(int baseValue, IList<IEnhancement<IStatistic>> enhancements)
        {
            SetBaseValue(baseValue);
            Enhancements = enhancements;
        }

        public void SetBaseValue(int baseValue) =>
            this.baseValue = baseValue >= Minimum
                ? baseValue
                : throw new ArgumentException($"{nameof(baseValue)}:{baseValue} cannot be less than {Minimum}.");
    }
}