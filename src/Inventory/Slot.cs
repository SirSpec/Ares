using System;

namespace Ares.Inventory
{
    public class Slot
    {
        private IEquipable? item;

        public bool IsEmpty => item is null;
        public SlotType Type { get; }

        public IEquipable Item
        {
            get => item ?? throw new InvalidOperationException($"{nameof(Slot)} is Empty.");
            set => item = value.SlotType == Type
                ? value
                : throw new InvalidOperationException($"{nameof(SlotType)} of the Item:{value.SlotType} is invalid:{Type}.");
        }

        public Slot(SlotType type) =>
            Type = type;
    }
}