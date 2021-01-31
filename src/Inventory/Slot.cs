using System;

namespace Ares.Inventory
{
    public class Slot
    {
        private IEquipable? item;

        public bool IsEmpty => item is null;
        public Enum SlotType { get; }

        public IEquipable Item
        {
            get => item ?? throw new InvalidOperationException($"{nameof(Slot)} is Empty.");
            set => item = value is null || value.SlotType.HasFlag(SlotType)
                ? value
                : throw new InvalidOperationException($"{nameof(SlotType)} of the Item:{value.SlotType} is invalid:{SlotType}.");
        }

        public Slot(Enum slotType) =>
            SlotType = slotType;
    }
}