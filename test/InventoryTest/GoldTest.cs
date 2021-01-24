using Ares.Inventory;
using System;
using Xunit;

namespace Ares.InventoryTest
{
    public class GoldTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new Gold(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void AddOperator_Add5And10_15()
        {
            //Arrange
            var sut1 = new Gold(5);
            var sut2 = new Gold(10);

            //Act
            var value = sut1 + sut2;

            //Assert
            Assert.Equal(15, value.Value);
        }

        [Fact]
        public void SubtractOperator_Subtract10And10_Zero()
        {
            //Arrange
            var sut1 = new Gold(10);
            var sut2 = new Gold(10);

            //Act
            var value = sut1 - sut2;

            //Assert
            Assert.Equal(0, value.Value);
        }
    }
}