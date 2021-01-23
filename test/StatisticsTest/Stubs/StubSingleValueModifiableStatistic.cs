using Ares.Statistics.Base;

namespace Ares.StatisticsTest.Stubs
{
    public class StubSingleValueModifiableStatistic : IModifiableStatistic
    {
        private int baseValue;

        public int BaseValue => baseValue;
        public int Value => BaseValue;

        public StubSingleValueModifiableStatistic(int baseValue) =>
            this.baseValue = baseValue;

        public void SetBaseValue(int value) =>
            baseValue = value;
    }
}
