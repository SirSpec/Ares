using Ares.Statistics;

namespace Ares.StatisticsTest.Stubs
{
    public class StubSingleValueStatistic : IStatistic
    {
        private readonly int baseValue;

        public string Name => throw new System.NotImplementedException();
        public int BaseValue => baseValue;
        public int Value => baseValue;

        public StubSingleValueStatistic(int baseValue) =>
            this.baseValue = baseValue;
    }
}
