using System;
using Ares.Inventory;
using Ares.InventoryTest.Stubs;
using Xunit;

namespace Ares.InventoryTest
{
    public class BackpackTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new Backpack(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void IsFull_ZeroCapacity_True()
        {
            //Arrange
            var sut = new Backpack(0);

            //Act
            var result = sut.IsFull;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Put_OneItemCapacity_FullBackpack()
        {
            //Arrange
            var sut = new Backpack(1);
            var item = new StubSimpleItem();

            //Act
            sut.Put(item);

            //Assert
            Assert.True(sut.IsFull);
            Assert.Equal(item.Weight.Value, sut.Weight.Value);
        }

        [Fact]
        public void Put_MoreItemsThanCapacity_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Backpack(1);
            var item1 = new StubSimpleItem();
            var item2 = new StubSimpleItem();

            //Act
            sut.Put(item1);
            Action result = () => sut.Put(item2);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }


        [Fact]
        public void Put_TheSameItemTwice_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Backpack(2);
            var item = new StubSimpleItem();
            sut.Put(item);

            //Act
            Action result = () => sut.Put(item);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact]
        public void Weight_TwoItems_SumOfItemsWeight()
        {
            //Arrange
            var sut = new Backpack(2);
            var item1 = new StubSimpleItem();
            var item2 = new StubSimpleItem();

            //Act
            sut.Put(item1);
            sut.Put(item2);

            //Assert
            Assert.Equal(item1.Weight + item2.Weight, sut.Weight);
        }

        [Fact]
        public void Contains_PutItem_True()
        {
            //Arrange
            var sut = new Backpack(1);
            var item = new StubSimpleItem();

            //Act
            sut.Put(item);

            //Assert
            Assert.True(sut.Contains(item));
        }

        [Fact]
        public void Remove_ExistingItem_ValidOperation()
        {
            //Arrange
            var sut = new Backpack(1);
            var item = new StubSimpleItem();

            //Act
            sut.Put(item);
            sut.Remove(item);

            //Assert
            Assert.False(sut.Contains(item));
            Assert.False(sut.IsFull);
        }

        [Fact]
        public void Remove_NonExistingItem_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Backpack(1);
            var item1 = new StubSimpleItem();
            var item2 = new StubSimpleItem();
            sut.Put(item1);

            //Act
            Action result = () => sut.Remove(item2);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }
    }
}