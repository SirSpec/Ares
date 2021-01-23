using Ares.StatisticsTest.Stubs;
using Xunit;

namespace StatisticsTest
{
    public class ModifiableStatisticTest
    {
        [Fact]
        public void SetBaseValue_IncreasedByFive_ValueIncreasedByFive()
        {
            //Arrange
            var expectedValue = 5;
            var sut = new StubSingleValueModifiableStatistic(1);

            //Act
            sut.SetBaseValue(expectedValue);
            var baseValue = sut.BaseValue;
            var value = sut.Value;

            //Assert
            Assert.Equal(expectedValue, baseValue);
            Assert.Equal(expectedValue, value);
        }
    }
}
