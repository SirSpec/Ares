using System;

namespace Ares.Inventory
{
    public class UnequipedEventArgs : EventArgs
    {
        public IEquipable UnequipedItem { get; }

        public UnequipedEventArgs(IEquipable unequipedItem) =>
            UnequipedItem = unequipedItem;
    }
}