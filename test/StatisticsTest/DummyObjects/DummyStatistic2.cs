using Ares.Statistics.Base;

namespace Ares.StatisticsTest.DummyObjects
{
    public class DummyStatistic2 : IStatistic
    {
        public int Value => throw new System.NotImplementedException();

        public int BaseValue => throw new System.NotImplementedException();
    }
}
