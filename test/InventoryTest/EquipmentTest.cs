using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.InventoryTest.Stubs;
using Xunit;

namespace Ares.InventoryTest
{
    public class EquipmentTest
    {
        private IList<Slot> ValidSlots => new List<Slot> {
            new Slot(SlotTypeStub.Slot1),
            new Slot(SlotTypeStub.Slot2),
            new Slot(SlotTypeStub.Slot3),
            new Slot(SlotTypeStub.Slot4),
            new Slot(SlotTypeStub.Slot5),
            new Slot(SlotTypeStub.Slot6)
        };

        private IList<Slot> InvalidSlots => new List<Slot> {
            new Slot(SlotTypeStub.Slot1),
            new Slot(SlotTypeStub.Slot1)
        };

        [Fact]
        public void Constructor_DuplicatedSlotTypeStub_ThrowArgumentException()
        {
            //Arrange Act
            Action action = () => new Equipment(InvalidSlots);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Weight_Empty_Zero()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);

            //Assert
            Assert.Equal(Weight.Zero, sut.Weight);
        }

        [Fact]
        public void Equip_ValidItem_ItemSet()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem = new EquipableItemStub();

            //Act
            sut.Equip(testItem);

            //Assert
            Assert.Equal(testItem.Weight, sut.Weight);
            Assert.Contains(testItem, sut.EquipedItems);
        }

        [Fact]
        public void Equip_TheSameItemType_ReplaceItem()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Assert
            Assert.Equal(testItem2.Weight, sut.Weight);
            Assert.Contains(testItem2, sut.EquipedItems);
            Assert.DoesNotContain(testItem1, sut.EquipedItems);
        }

        [Fact]
        public void EquipedEvent_ValidItem_NewItemEventTriggered()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            Action action = () => sut.Equip(testItem);

            //Assert
            Assert.Raises<EquipedEventArgs>(
                handler => sut.Equiped += handler,
                handler => sut.Equiped -= handler,
                action);
        }

        [Fact]
        public void EquipedEvent_TheSameItemType_ReplaceItemEventTriggered()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            sut.Equip(testItem1);
            Action action = () => sut.Equip(testItem2);

            //Assert
            Assert.Raises<EquipedEventArgs>(
                handler => sut.Equiped += handler,
                handler => sut.Equiped -= handler,
                action);
        }

        [Fact]
        public void Weight_MultipleItems_SumOfItemsWeight()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot2);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Assert
            Assert.Equal(testItem1.Weight + testItem2.Weight, sut.Weight);
        }
    }
}