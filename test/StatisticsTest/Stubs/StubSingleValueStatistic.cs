using Ares.Statistics.Base;

namespace Ares.StatisticsTest.Stubs
{
    public class StubSingleValueStatistic : IStatistic
    {
        private readonly int baseValue;

        public int BaseValue => baseValue;
        public int Value => baseValue;

        public StubSingleValueStatistic(int baseValue) =>
            this.baseValue = baseValue;
    }
}
