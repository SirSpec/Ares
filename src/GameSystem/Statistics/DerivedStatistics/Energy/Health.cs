using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;
using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Energy
{
    public class Health : IStatistic, IEnhanceable
    {
        private const int HealthPerStrength = 12;
        private readonly Strength strength;

        public string Name { get; } = "Health";
        public int BaseValue => HealthPerStrength * strength.Value;
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));

        public Health(Strength strength) : this(strength, new List<IEnhancement<IStatistic>>())
        {
        }

        public Health(Strength strength, IList<IEnhancement<IStatistic>> enhancements)
        {
            this.strength = strength;
            Enhancements = enhancements;
        }
    }
}