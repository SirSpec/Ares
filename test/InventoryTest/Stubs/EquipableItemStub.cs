using System;
using Ares.Inventory;

namespace Ares.InventoryTest.Stubs
{
    public class EquipableItemStub : IEquipable
    {
        public string Name => "EquipableItemStub";

        public Weight Weight { get; } = new Weight(new Random().Next(1, 5));

        public Enum SlotType { get; }

        public EquipableItemStub() =>
            SlotType = SlotTypeStub.Slot1;

        public EquipableItemStub(Weight weight) : this() =>
            Weight = weight;

        public EquipableItemStub(Enum slotType) =>
            SlotType = slotType;
    }
}