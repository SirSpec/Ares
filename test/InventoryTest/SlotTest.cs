using System;
using Ares.Inventory;
using Ares.InventoryTest.Stubs;
using Xunit;

namespace Ares.InventoryTest
{
    public class SlotTest
    {
        [Fact]
        public void Constructor_IsEmpty_True()
        {
            //Arrange
            var sut = new Slot(SlotTypeStub.Slot1);

            //Assert
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void ItemGetter_EmptySlot_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Slot(SlotTypeStub.Slot1);

            // Act
            Func<IEquipable> action = () => sut.Item;

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void ItemSetter_SetItemOfTheSameSlotType_Item()
        {
            //Arrange
            var sut = new Slot(SlotTypeStub.Slot1);
            var item = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            sut.Item = item;

            //Assert
            Assert.Equal(item, sut.Item);
        }

        [Fact]
        public void ItemSetter_SetItemOfDifferentSlotType_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Slot(SlotTypeStub.Slot1);
            var item = new EquipableItemStub(SlotTypeStub.Slot2);

            //Act
            Action action = () => sut.Item = item;

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}