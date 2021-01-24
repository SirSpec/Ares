using System;

namespace Ares.Inventory
{
    public class EquipedEventArgs : EventArgs
    {
        public IEquipable? OldItem { get; }
        public IEquipable? NewItem { get; }

        public EquipedEventArgs(IEquipable item) =>
            NewItem = item;

        public EquipedEventArgs(IEquipable oldItem, IEquipable newItem) =>
            (OldItem, NewItem) = (oldItem, newItem);
    }
}