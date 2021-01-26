using System;
using Ares.Statistics.Base;
using Ares.StatisticsTest.Stubs;
using Xunit;

namespace Ares.StatisticsTest
{
    public class EnhanceableStatisticTest
    {
        [Fact]
        public void AddEnhancement_AddTheSameEnhancementTwice_InvalidOperationException()
        {
            //Arrange
            var enhancement = new StubEnhancement(0);
            IEnhanceable sut = new StubEnhanceableStatistic();

            //Act
            sut.AddEnhancement(enhancement);
            Action action = () => sut.AddEnhancement(enhancement);
            
            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void AddEnhancement_AddEnhancement_EnhancementAddedToTheList()
        {
            //Arrange
            var enhancement = new StubEnhancement(0);
            IEnhanceable sut = new StubEnhanceableStatistic();

            //Act
            sut.AddEnhancement(enhancement);
            
            //Assert
            Assert.Contains(enhancement, sut.Enhancements);
        }

        [Fact]
        public void RemoveEnhancement_NotAddedEnhancement_InvalidOperationException()
        {
            //Arrange
            var enhancement = new StubEnhancement(0);
            IEnhanceable sut = new StubEnhanceableStatistic();

            //Act
            Action action = () => sut.RemoveEnhancement(enhancement);
            
            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveEnhancement_AddedEnhancement_Empty()
        {
            //Arrange
            var enhancement = new StubEnhancement(0);
            IEnhanceable sut = new StubEnhanceableStatistic();
            sut.AddEnhancement(enhancement);

            //Act
            sut.RemoveEnhancement(enhancement);
            
            //Assert
            Assert.Empty(sut.Enhancements);
        }
    }
}
