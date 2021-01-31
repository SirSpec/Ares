using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Equip_TheSameItemSlotType_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot1);
            sut.Equip(testItem1);

            //Act
            Action action = () => sut.Equip(testItem2);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Equip_MultiSlotItem_OccupiedMultipleSlots()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);

            //Act
            sut.Equip(testItem1);
            var result = sut.Slots.Where(slot => !slot.IsEmpty && slot.Item == testItem1);

            //Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Equip_ItemIntoAllocatedSlotByMultiSlotItem_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot1);
            sut.Equip(testItem1);

            //Act
            Action action = () => sut.Equip(testItem2);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Unequip_NotEquipedItem_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem = new EquipableItemStub();

            //Act
            Action action = () => sut.Unequip(testItem);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Unequip_ValidItem_EmptyEquipedItems()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1);
            sut.Equip(testItem1);

            //Act
            sut.Unequip(testItem1);
            var equipedItems = sut.EquipedItems;

            //Assert
            Assert.Empty(equipedItems);
        }

        [Fact]
        public void Unequip_MultislotItem_EmptyEquipedItems()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            sut.Equip(testItem1);

            //Act
            sut.Unequip(testItem1);
            var equipedItems = sut.EquipedItems;

            //Assert
            Assert.Empty(equipedItems);
        }

        [Fact]
        public void Unequip_MultiSlotItem_OtherItemsRemained()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot3);
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Act
            sut.Unequip(testItem1);
            var equipedItems = sut.EquipedItems;

            //Assert
            Assert.Single(equipedItems);
            Assert.Contains(testItem2, equipedItems);
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
        public void Weight_MultipleItems_SumOfItemsWeight()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot2);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Assert
            Assert.Equal(testItem1.Weight + testItem2.Weight, sut.Weight);
        }

        [Fact]
        public void Weight_MultiSlotItem_WeightOfMultislotItem()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);

            //Act
            sut.Equip(testItem1);
            var result = sut.Weight.Value;
            var expected = testItem1.Weight.Value;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Weight_MultiSlotItemAndSingleSlotItem_WeightEqualsSumOfEquipedItemsWeight()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            var testItem2 = new EquipableItemStub(SlotTypeStub.Slot3);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);
            var result = sut.Weight.Value;
            var expected = testItem1.Weight.Value + testItem2.Weight.Value;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EquipedItems_MultiSlotItem_OneEquipedItem()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);

            //Act
            sut.Equip(testItem1);
            var result = sut.EquipedItems;

            //Assert
            Assert.Single(result);
        }

        [Fact]
        public void EquipedEvent_ValidItem_EquipedEventTriggered()
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
        public void EquipedEvent_MultiSlotItem_EquipedItemEventTriggeredOnce()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            var eventTriggeredCounter = 0;
            sut.Equiped += (_, _) => eventTriggeredCounter++;

            //Act
            sut.Equip(testItem1);

            //Assert
            Assert.Equal(1, eventTriggeredCounter);
        }

        [Fact]
        public void UnequipedEvent_ValidItem_UnequipedEventTriggered()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem = new EquipableItemStub(SlotTypeStub.Slot1);

            //Act
            sut.Equip(testItem);
            Action action = () => sut.Unequip(testItem);

            //Assert
            Assert.Raises<UnequipedEventArgs>(
                handler => sut.Unequiped += handler,
                handler => sut.Unequiped -= handler,
                action);
        }

        [Fact]
        public void UnequipedEvent_MultiSlotItem_UnequipedItemEventTriggeredOnce()
        {
            //Arrange
            var sut = new Equipment(ValidSlots);
            var testItem1 = new EquipableItemStub(SlotTypeStub.Slot1 | SlotTypeStub.Slot2);
            var eventTriggeredCounter = 0;
            sut.Unequiped += (_, _) => eventTriggeredCounter++;

            //Act
            sut.Equip(testItem1);
            sut.Unequip(testItem1);

            //Assert
            Assert.Equal(1, eventTriggeredCounter);
        }
    }
}