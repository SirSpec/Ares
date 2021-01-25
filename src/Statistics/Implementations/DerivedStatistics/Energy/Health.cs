using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Energy
{
    public class Health : IStatistic, IEnhanceable
    {
        private const int HealthPerStrength = 12;
        private readonly Strength strength;

        public string Name { get; } = "Health";
        public int BaseValue => HealthPerStrength * strength.Value;
        public IList<IEnhancement> Enhancements { get; }

        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));

        public Health(Strength strength) : this(strength, new List<IEnhancement>())
        {
        }

        public Health(Strength strength, IList<IEnhancement> enhancements)
        {
            this.strength = strength;
            Enhancements = enhancements;
        }
    }
}