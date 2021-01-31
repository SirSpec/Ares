using System;

namespace Ares.Inventory
{
    public class EquipedEventArgs : EventArgs
    {
        public IEquipable EquipedItem { get; }

        public EquipedEventArgs(IEquipable equipedItem) =>
            EquipedItem = equipedItem;
    }
}