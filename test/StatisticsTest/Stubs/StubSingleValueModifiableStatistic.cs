using Ares.Statistics;

namespace Ares.StatisticsTest.Stubs
{
    public class StubSingleValueModifiableStatistic : IModifiableStatistic
    {
        private int baseValue;

        public string Name => throw new System.NotImplementedException();
        public int BaseValue => baseValue;
        public int Value => BaseValue;

        public StubSingleValueModifiableStatistic(int baseValue) =>
            this.baseValue = baseValue;

        public void SetBaseValue(int value) =>
            baseValue = value;
    }
}
