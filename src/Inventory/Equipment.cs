using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Inventory
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;

        private readonly IList<Slot> slots;
        public IEnumerable<IEquipable> EquipedItems =>
            slots.Where(slot => !slot.IsEmpty).Select(slot => slot.Item);

        public Equipment(IList<Slot> slots) =>
            this.slots = DoesNotContainDuplicatedTypes(slots)
                ? slots
                : throw new ArgumentException($"{nameof(slots)} contains duplicated slot type.");

        public void Equip(IEquipable item)
        {
            var slot = slots.Single(slot => slot.SlotType.Equals(item.SlotType));

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

        private static bool DoesNotContainDuplicatedTypes(IEnumerable<Slot> slots)
        {
            var numberOfDuplicatedTypes = slots
                .GroupBy(slot => slot.SlotType)
                .Count(group => group.Count() > 1);

            return numberOfDuplicatedTypes == 0;
        }
    }
}