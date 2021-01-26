using System;
using System.Collections.Generic;
using Ares.Statistics;
using Ares.Statistics.Base;
using Ares.StatisticsTest.DummyObjects;
using Xunit;

namespace Ares.StatisticsTest
{
    public class StatisticsSetConstructorTest
    {
        public IEnumerable<IStatistic> DuplicatedStatistics => new List<IStatistic>
        {
            new DummyStatistic1(),
            new DummyStatistic1()
        };

        [Fact]
        public void Constructor_DuplicatedStatistics_ArgumentException()
        {
            //Arrange Act 
            Action sut = () => new StatisticsSet(DuplicatedStatistics);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
