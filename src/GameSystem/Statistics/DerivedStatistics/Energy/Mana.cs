using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;
using GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace GameSystem.Statistics.DerivedStatistics.Energy
{
    public class Mana : IStatistic, IEnhanceable
    {
        private const int ManaPerIntelligence = 6;
        private readonly Intelligence intelligence;

        public string Name { get; } = "Mana";
        public int BaseValue => ManaPerIntelligence * intelligence.Value;
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));

        public Mana(Intelligence intelligence) : this(intelligence, new List<IEnhancement<IStatistic>>())
        {
        }

        public Mana(Intelligence intelligence, IList<IEnhancement<IStatistic>> enhancements)
        {
            this.intelligence = intelligence;
            Enhancements = enhancements;
        }
    }
}