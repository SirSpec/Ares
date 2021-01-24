using System.Collections.Generic;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;

namespace Ares.StatisticsTest.Stubs
{
    public class StubEnhanceableStatistic : IStatistic, IEnhanceable
    {
        public string Name => throw new System.NotImplementedException();
        public int BaseValue => throw new System.NotImplementedException();
        public int Value => throw new System.NotImplementedException();

        public IList<IEnhancement> Enhancements { get; }

        public StubEnhanceableStatistic()
        {
            Enhancements = new List<IEnhancement>();
        }
    }
}
