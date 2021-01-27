using System;
using GameSystem;
using Xunit;

namespace Ares.GameSystemTest
{
    public class EnergyPoolTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new EnergyPool(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_NegativeInputs_ThrowsArgumentException()
        {
            //Arrange
            Action sut1 = () => new EnergyPool(-1, 1);
            Action sut2 = () => new EnergyPool(1, -1);

            //Assert
            Assert.Throws<ArgumentException>(sut1);
            Assert.Throws<ArgumentException>(sut2);
        }

        [Fact]
        public void Constructor_InvalidInputs_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new EnergyPool(2, 1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Increase_ExceedTotal_Total()
        {
            //Arrange
            var total = 5;
            var sut = new EnergyPool(1, total);

            //Act
            sut.Increase(10);

            //Assert
            Assert.Equal(total, sut.Current);
            Assert.Equal(total, sut.Total);
        }

        [Fact]
        public void Decrease_ExceedZero_Zero()
        {
            //Arrange
            var total = 5;
            var sut = new EnergyPool(total);

            //Act
            sut.Decrease(10);

            //Assert
            Assert.Equal(0, sut.Current);
            Assert.Equal(total, sut.Total);
        }
    }
}