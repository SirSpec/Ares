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
        public void AddOperator_Add_SumOfBothWeights()
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
        public void SubtractOperator_SubtractLesserFromGreater_ValidWeight()
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
        public void SubtractOperator_SubtractEqualWeights_Zero()
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
        public void SmallerOrEqualOperator_TheSameWeights_True()
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
        public void SmallerOrEqualOperator_GreaterAndSmaller_False()
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
        public void GreaterOrEqualOperator_TheSameWeights_True()
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
        public void GreaterOrEqualOperator_SmallerAndGreater_False()
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