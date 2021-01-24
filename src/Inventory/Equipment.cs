using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Inventory
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;

        private readonly IList<Slot> slots;
        public IEnumerable<IEquipable> EquipedItems => slots.Where(slot => !slot.IsEmpty).Select(slot => slot.Item);
        public bool IsUnarmed => slots.Single(slot => slot.Type == SlotType.MainHand).IsEmpty;

        public Equipment()
        {
            slots = new List<Slot>();
            foreach (SlotType type in Enum.GetValues(typeof(SlotType)))
                slots.Add(new Slot(type));
        }

        public void Equip(IEquipable item)
        {
            var slot = slots.Single(slot => slot.Type == item.SlotType);

            if (slot.IsEmpty)
            {
                slot.Item = item;
                Equiped?.Invoke(this, new EquipedEventArgs(item));
            }
            else
            {
                var oldItem = slot.Item;
                slot.Item = item;
                Equiped?.Invoke(this, new EquipedEventArgs(oldItem, item));
            }
        }

        public Weight Weight =>
            EquipedItems.Aggregate(Weight.Zero, (seed, next) => seed += next.Weight);
    }
}