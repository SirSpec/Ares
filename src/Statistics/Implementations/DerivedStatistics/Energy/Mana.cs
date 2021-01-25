using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Energy
{
    public class Mana : IStatistic, IEnhanceable
    {
        private const int ManaPerIntelligence = 6;
        private readonly Intelligence intelligence;

        public string Name { get; } = "Mana";
        public int BaseValue => ManaPerIntelligence * intelligence.Value;
        public IList<IEnhancement> Enhancements { get; }

        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));

        public Mana(Intelligence intelligence) : this(intelligence, new List<IEnhancement>())
        {
        }

        public Mana(Intelligence intelligence, IList<IEnhancement> enhancements)
        {
            this.intelligence = intelligence;
            Enhancements = enhancements;
        }
    }
}