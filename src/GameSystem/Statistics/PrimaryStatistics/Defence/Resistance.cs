using Ares.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace Ares.GameSystem.Statistics.PrimaryStatistics.Defence
{
    public abstract class Resistance : IStatistic, IEnhanceable
    {
        public const int Minimum = 0;
        public const int Maximum = 70;

        public abstract string Name { get; }
        public int BaseValue { get; } = Minimum;
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public int Value => EnhancementsValue <= Minimum
            ? Minimum
            : EnhancementsValue >= Maximum
                ? Maximum
                : EnhancementsValue;

        public Resistance() : this(new List<IEnhancement<IStatistic>>())
        {
        }

        public Resistance(IList<IEnhancement<IStatistic>> enhancements) =>
            Enhancements = enhancements;

        private int EnhancementsValue =>
            Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));
    }
}