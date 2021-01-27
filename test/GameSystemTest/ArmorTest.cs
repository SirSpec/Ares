using System;
using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Statistics.PrimaryStatistics.Defence;
using Xunit;

namespace Ares.GameSystemTest
{
    public class ArmorTest
    {
        [Fact]
        public void SetBaseValue_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Armor();

            //Act
            Action action = () => sut.SetBaseValue(-1);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_Default_Zero()
        {
            //Arrange
            var sut = new Armor();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void SetBaseValue_PositiveValue_PositiveValue()
        {
            //Arrange
            const int expectedValue = 5;
            var sut = new Armor();

            //Act
            sut.SetBaseValue(expectedValue);

            //Assert
            Assert.Equal(expectedValue, sut.Value);
        }

        [Fact]
        public void Value_Enhanced_EnhancedValue()
        {
            //Arrange
            var sut = new Armor();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(10, results);
        }

        [Fact]
        public void BaseValue_Enhanced_BaseValueNotChanged()
        {
            //Arrange
            var sut = new Armor();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }
    }
}