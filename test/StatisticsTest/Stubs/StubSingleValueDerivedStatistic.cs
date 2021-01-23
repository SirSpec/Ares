using Ares.Statistics.Base;

namespace Ares.StatisticsTest.Stubs
{
    public class StubSingleValueDerivedStatistic : IStatistic
    {
        private readonly int baseValue;
        private readonly StubSingleValueStatistic stubSimpleStatistic;

        public int BaseValue => baseValue;
        public int Value => baseValue + stubSimpleStatistic.Value;

        public StubSingleValueDerivedStatistic(int baseValue, StubSingleValueStatistic stubSimpleStatistic)
        {
            this.baseValue = baseValue;
            this.stubSimpleStatistic = stubSimpleStatistic;
        }
    }
}
