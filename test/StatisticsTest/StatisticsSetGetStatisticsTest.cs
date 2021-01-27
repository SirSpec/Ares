using System.Collections.Generic;
using System.Linq;
using Ares.Statistics;
using Ares.StatisticsTest.DummyObjects;
using Ares.StatisticsTest.Stubs;
using Xunit;

namespace Ares.StatisticsTest
{
    public class StatisticsSetGetStatisticsTest
    {
        public IEnumerable<IStatistic> ValidStatistics => new List<IStatistic>
        {
            new DummyStatistic1(),
            new DummyStatistic2(),
            new StubSingleValueModifiableStatistic(0)
        };

        [Fact]
        public void GetStatistics_IStatistic_AllStatistics()
        {
            //Arrange
            var sut = new StatisticsSet(ValidStatistics);

            //Act
            var statistics = sut.GetStatistics<IStatistic>();

            //Assert
            Assert.Equal(ValidStatistics.Count(), statistics.Count());

            foreach (var statistic in statistics)
            {
                Assert.IsAssignableFrom<IStatistic>(statistic);
            }
        }
        
        [Fact]
        public void GetStatistics_IModifiableStatistic_AllModifiableStatistics()
        {
            //Arrange
            var sut = new StatisticsSet(ValidStatistics);

            //Act
            var statistics = sut.GetStatistics<IModifiableStatistic>();

            //Assert
            Assert.Single(statistics);

            foreach (var statistic in statistics)
            {
                Assert.IsAssignableFrom<IModifiableStatistic>(statistic);
            }
        }
    }
}
