using System;

namespace Ares.Inventory
{
    public interface IEquipable : IItem
    {
        Enum SlotType { get; }
    }
}