using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.InventoryTest.Stubs;
using Xunit;

namespace Ares.InventoryTest
{
    public class InventorySetTest
    {
        private IList<Slot> ValidSlots => new List<Slot> {
            new Slot(SlotTypeStub.Slot1),
            new Slot(SlotTypeStub.Slot2),
            new Slot(SlotTypeStub.Slot3),
            new Slot(SlotTypeStub.Slot4),
            new Slot(SlotTypeStub.Slot5),
            new Slot(SlotTypeStub.Slot6)
        };

        [Fact]
        public void Default_NewObject_DefaultValues()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);

            //Assert
            Assert.Equal(Weight.Zero, sut.Weight);
            Assert.Equal(Gold.Zero, sut.Gold);
            Assert.Equal(carryingCapacity, sut.CarryingCapacity);
        }

        [Fact]
        public void ChangeCarryingCapacity_EmptySet_NewCarryingCapacity()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var newCapacity = new Weight(10);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);

            //Act
            sut.ChangeCarryingCapacity(newCapacity);

            //Assert
            Assert.Equal(newCapacity, sut.CarryingCapacity);
        }

        [Fact]
        public void Weight_AddItemWithValidWeight_WeightEqualsItemsWeight()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(3));

            //Act
            sut.Equipment.Equip(testItem);

            //Assert
            Assert.Equal(testItem.Weight, sut.Weight);
        }

        [Fact]
        public void ChangeCarryingCapacity_CapacitySmallerThanWeight_ThrowsI()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var newCapacity = new Weight(3);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(4));

            //Act
            sut.Equipment.Equip(testItem);
            Action action = () => sut.ChangeCarryingCapacity(newCapacity);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Earn_ValidGold_ValidGold()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var gold = new Gold(5);

            //Act
            sut.Earn(gold);

            //Assert
            Assert.Equal(gold, sut.Gold);
        }

        [Fact]
        public void Spend_ValidGold_ValidGold()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var earnedGold = new Gold(5);
            var spentGold = new Gold(3);

            //Act
            sut.Earn(earnedGold);
            sut.Spend(spentGold);

            //Assert
            Assert.Equal(earnedGold.Value - spentGold.Value, sut.Gold.Value);
        }

        [Fact]
        public void Spend_MoreThanHave_ThrowsInvalidOperationException()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var spentGold = new Gold(1);

            //Act
            Action action = () => sut.Spend(spentGold);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void CanPickUp_AddItemWithValidWeight_True()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(5));

            //Act
            var result = sut.CanPickUp(testItem);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CanPickUp_AddItemWithInvalidWeight_False()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(6));

            //Act
            var result = sut.CanPickUp(testItem);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void PickUp_AddItemWithValidWeight_ValidItem()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(5));

            //Act
            sut.PickUp(testItem);

            //Assert
            Assert.Contains(testItem, sut.Backpack.Items);
        }

        [Fact]
        public void PickUp_AddTooHeavyItem_ThrowsInvalidOperationException()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(6));

            //Act
            Action action = () => sut.PickUp(testItem);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveItem_NonExistingItem_ThrowsInvalidOperationException()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub();

            //Act
            Action action = () => sut.RemoveItem(testItem);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveItem_ExistingItem_ItemRemoved()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(3));

            //Act
            sut.PickUp(testItem);
            sut.RemoveItem(testItem);

            //Assert
            Assert.Empty(sut.Backpack.Items);
        }

        [Fact]
        public void Equip_ExistingItem_ItemEquiped()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(3));

            //Act
            sut.PickUp(testItem);
            sut.Equip(testItem);

            //Assert
            Assert.Contains(testItem, sut.Equipment.EquipedItems);
            Assert.DoesNotContain(testItem, sut.Backpack.Items);
        }

        [Fact]
        public void Equip_NonExistingItem_ThrowsInvalidOperationException()
        {
            //Arrange
            var carryingCapacity = new Weight(5);
            var sut = new InventorySet(new Equipment(ValidSlots), new Backpack(3), carryingCapacity);
            var testItem = new EquipableItemStub(new Weight(3));

            //Act
            Action action = () => sut.Equip(testItem);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}