using Ares.Inventory;
using System;
using Xunit;

namespace Ares.InventoryTest
{
    public class WeightTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new Weight(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void AddOperator_Add5And10_15()
        {
            //Arrange
            var sut1 = new Weight(5);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 + sut2;

            //Assert
            Assert.Equal(15, value.Value);
        }

        [Fact]
        public void SubtractOperator_Subtract10And5_Five()
        {
            //Arrange
            var sut1 = new Weight(10);
            var sut2 = new Weight(5);

            //Act
            var value = sut1 - sut2;

            //Assert
            Assert.Equal(5, value.Value);
        }

        [Fact]
        public void SubtractOperator_Subtract10And10_Zero()
        {
            //Arrange
            var sut1 = new Weight(10);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 - sut2;

            //Assert
            Assert.Equal(0, value.Value);
        }

        [Fact]
        public void SmallerOrEqualOperator_10And10_True()
        {
            //Arrange
            var sut1 = new Weight(10);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 <= sut2;

            //Assert
            Assert.True(value);
        }

        [Fact]
        public void SmallerOrEqualOperator_15And10_False()
        {
            //Arrange
            var sut1 = new Weight(15);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 <= sut2;

            //Assert
            Assert.False(value);
        }

        [Fact]
        public void GreaterOrEqualOperator_10And10_True()
        {
            //Arrange
            var sut1 = new Weight(10);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 >= sut2;

            //Assert
            Assert.True(value);
        }

        [Fact]
        public void GreaterOrEqualOperator_5And10_False()
        {
            //Arrange
            var sut1 = new Weight(5);
            var sut2 = new Weight(10);

            //Act
            var value = sut1 >= sut2;

            //Assert
            Assert.False(value);
        }
    }
}