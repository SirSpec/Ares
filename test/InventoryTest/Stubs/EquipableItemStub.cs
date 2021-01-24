using System;
using Ares.Inventory;

namespace Ares.InventoryTest.Stubs
{
    public class EquipableItemStub : IEquipable
    {
        public string Name => "EquipableItemStub";

        public Weight Weight { get; } = new Weight(new Random().Next(1, 5));

        public SlotType SlotType { get; }

        public EquipableItemStub() =>
            SlotType = SlotType.Chest;

        public EquipableItemStub(Weight weight) =>
            Weight = weight;

        public EquipableItemStub(SlotType slotType) =>
            SlotType = slotType;
    }
}