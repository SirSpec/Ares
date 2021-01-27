using Xunit;
using Ares.Statistics.Enhancements;
using Ares.Statistics.Base;

namespace Ares.StatisticsTest.Implementations
{
    public class EnhancementTest
    {
        [Fact]
        public void FlatEnhance_One_One()
        {
            //Arrange
            var flatValue = 5;
            var sut = new FlatEnhancement<IStatistic>(flatValue);

            //Act
            var results = sut.Enhance(2);

            //Assert
            Assert.Equal(flatValue, results);
        }

        [Fact]
        public void PercentageEnhancement_50_50PercentOfValue()
        {
            //Arrange
            var sut = new PercentageEnhancement<IStatistic>(50);

            //Act
            var results = sut.Enhance(10);

            //Assert
            Assert.Equal(5, results);
        }
    }
}