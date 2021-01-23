using Ares.StatisticsTest.Stubs;
using Xunit;

namespace StatisticsTest
{
    public class StatisticValueTest
    {
        [Fact]
        public void Value_InitializedWithExpectedValue_ExpectedValue()
        {
            //Arrange
            var expectedValue = 1;
            var sut = new StubSingleValueStatistic(expectedValue);

            //Act
            var baseValue = sut.BaseValue;
            var value = sut.Value;

            //Assert
            Assert.Equal(expectedValue, baseValue);
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void Value_InitializedDerivedStatistic_DerivedValue()
        {
            //Arrange
            var primaryBaseValue = 5;
            var derivedBaseValue = 10;
            var expectedValue = primaryBaseValue + derivedBaseValue;

            var primaryStatistic = new StubSingleValueStatistic(primaryBaseValue);
            var sut = new StubSingleValueDerivedStatistic(derivedBaseValue, primaryStatistic);

            //Act
            var baseValue = sut.BaseValue;
            var value = sut.Value;

            //Assert
            Assert.Equal(derivedBaseValue, baseValue);
            Assert.Equal(expectedValue, value);
        }
    }
}
