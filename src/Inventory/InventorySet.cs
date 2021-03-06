﻿using System;

namespace Ares.Inventory
{
    public class InventorySet
    {
        public Equipment Equipment { get; }
        public Backpack Backpack { get; }
        public Gold Gold { get; private set; }
        public Weight CarryingCapacity { get; private set; }

        public Weight Weight => Equipment.Weight + Backpack.Weight;

        public InventorySet(Equipment equipment, Backpack backpack, Weight carryingCapacity)
        {
            (Equipment, Backpack, CarryingCapacity) = (equipment, backpack, carryingCapacity);
            Equipment.Unequiped += (_, args) => Backpack.Put(args.UnequipedItem);
        }

        public void ChangeCarryingCapacity(Weight carryingCapacity) =>
            CarryingCapacity = carryingCapacity.Value >= Weight.Value
                ? carryingCapacity
                : throw new InvalidOperationException(
                    $"{nameof(carryingCapacity)}:{carryingCapacity} is smaller than Weight of items:{Weight}.");

        public void Earn(Gold gold) =>
            Gold += gold;

        public void Spend(Gold gold) =>
            Gold -= Gold.Value - gold.Value >= 0
                ? gold
                : throw new InvalidOperationException($"Not enough gold: {Gold}.");

        public bool CanPickUp(IItem item) =>
            Weight + item.Weight <= CarryingCapacity && !Backpack.IsFull;

        public void PickUp(IItem item)
        {
            if (CanPickUp(item)) Backpack.Put(item);
            else throw new InvalidOperationException(
                $"Item Weight:{Weight} exceeds Carrying Capacity:{CarryingCapacity}.");
        }

        public void RemoveItem(IItem item)
        {
            if (Backpack.Contains(item)) Backpack.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }

        public void Equip(IEquipable item)
        {
            if (Backpack.Contains(item))
            {
                Equipment.Equip(item);
                Backpack.Remove(item);
            }
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}
