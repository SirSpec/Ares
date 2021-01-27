using System.Collections.Generic;
using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Enhancements;
using Xunit;

namespace Ares.StatisticsTest
{
    public class StatisticEnhancementsTest
    {
        public IEnumerable<IStatistic> ValidStatistics => new List<IStatistic>
        {
            new StubEnhanceableStatistic(),
        };

        [Fact]
        public void Apply_FlatStubEnhanceableStatisticModifier_NewStubEnhanceableStatisticValue()
        {
            //Arrange
            var statistics = new StatisticsSet(ValidStatistics);
            var sut = new FlatEnhancement<StubEnhanceableStatistic>(10);
            statistics.Apply(sut);

            //Act
            var result = statistics.GetStatistic<StubEnhanceableStatistic>().Enhancements;

            //Assert
            Assert.Contains(sut, result);
        }

        [Fact]
        public void Apply_MultipleStubEnhanceableStatisticModifier_NewStubEnhanceableStatisticValue()
        {
            //Arrange
            var statistics = new StatisticsSet(ValidStatistics);
            var sut = new IEnhancement<IStatistic>[] { new FlatEnhancement<StubEnhanceableStatistic>(10), new PercentageEnhancement<StubEnhanceableStatistic>(20) };
            statistics.Apply(sut);

            //Act
            var result = statistics.GetStatistic<StubEnhanceableStatistic>().Enhancements;

            //Assert
            foreach (var item in sut)
                Assert.Contains(item, result);
        }

        [Fact]
        public void Remove_FlatStubEnhanceableStatisticModifier_DefaultValue()
        {
            //Arrange
            var statistics = new StatisticsSet(ValidStatistics);
            var sut = new FlatEnhancement<StubEnhanceableStatistic>(10);
            statistics.Apply(sut);

            //Act
            statistics.Remove(sut);
            var result = statistics.GetStatistic<StubEnhanceableStatistic>().Enhancements;

            //Assert
            Assert.DoesNotContain(sut, result);
        }

        [Fact]
        public void Remove_MultipleStubEnhanceableStatisticModifier_DefaultValue()
        {
            //Arrange
            var statistics = new StatisticsSet(ValidStatistics);
            var sut = new IEnhancement<IStatistic>[] { new FlatEnhancement<StubEnhanceableStatistic>(10), new PercentageEnhancement<StubEnhanceableStatistic>(20) };
            statistics.Apply(sut);

            //Act
            statistics.Remove(sut);
            var result = statistics.GetStatistic<StubEnhanceableStatistic>().Enhancements;

            //Assert
            foreach (var item in sut)
                Assert.DoesNotContain(item, result);
        }
    }
}