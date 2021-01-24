using System;
using System.Collections.Generic;
using Ares.Statistics;
using Ares.Statistics.Base;
using Ares.StatisticsTest.DummyObjects;
using Xunit;

namespace StatisticsTest
{
    public class NonInitializedStatistic : IStatistic
    {
        public string Name => throw new NotImplementedException();
        public int BaseValue => throw new NotImplementedException();
        public int Value => throw new NotImplementedException();
    }

    public class StatisticsSetGetStatisticTest
    {
        public IEnumerable<IStatistic> ValidStatistics => new List<IStatistic>
        {
            new DummyStatistic1(),
            new DummyStatistic2()
        };

        [Fact]
        public void GetStatistic_GetNotInitializedStatistic_ThrowInvalidOperationException()
        {
            //Arrange
            var sut = new StatisticsSet(ValidStatistics);

            //Act
            Action getNonInitializedStatistic = () => sut.GetStatistic<NonInitializedStatistic>();

            //Assert
            Assert.Throws<InvalidOperationException>(getNonInitializedStatistic);
        }

        [Fact]
        public void GetStatistic_IStatistic_ThrowInvalidOperationException()
        {
            //Arrange
            var sut = new StatisticsSet(ValidStatistics);

            //Act
            Action getStatistic = () => sut.GetStatistic<IStatistic>();

            //Assert
            Assert.Throws<InvalidOperationException>(getStatistic);
        }

        [Fact]
        public void GetStatistic_InitializedStatistic_ValidStatistic()
        {
            //Arrange
            var sut = new StatisticsSet(ValidStatistics);

            //Act
            var statistic = sut.GetStatistic<DummyStatistic1>();

            //Assert
            Assert.NotNull(statistic);
            Assert.IsType<DummyStatistic1>(statistic);
        }
    }
}
