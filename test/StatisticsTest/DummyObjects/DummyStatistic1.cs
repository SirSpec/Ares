using Ares.Statistics;

namespace Ares.StatisticsTest.DummyObjects
{
    public class DummyStatistic1 : IStatistic
    {
        public string Name => throw new System.NotImplementedException();
        public int BaseValue => throw new System.NotImplementedException();
        public int Value => throw new System.NotImplementedException();
    }
}
