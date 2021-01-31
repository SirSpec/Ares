using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Inventory
{
    public class Equipment
    {
        public event EventHandler<EquipedEventArgs>? Equiped;
        public event EventHandler<UnequipedEventArgs>? Unequiped;

        public Equipment(IList<Slot> slots) =>
            Slots = DoesNotContainDuplicatedTypes(slots)
                ? slots
                : throw new ArgumentException($"{nameof(slots)} contains duplicated slot type.");

        public IList<Slot> Slots { get; }

        public IEnumerable<IEquipable> EquipedItems =>
            Slots.Where(slot => !slot.IsEmpty).Select(slot => slot.Item).Distinct();

        public Weight Weight =>
            EquipedItems.Aggregate(Weight.Zero, (seed, next) => seed += next.Weight);

        public void Equip(IEquipable item)
        {
            var slots = Slots.Where(slot => item.SlotType.HasFlag(slot.SlotType));

            if (slots.All(slot => slot.IsEmpty))
            {
                foreach (var slot in slots)
                    slot.Item = item;
                Equiped?.Invoke(this, new EquipedEventArgs(item));
            }
            else throw new ArgumentException(
                $"Could not find valid {nameof(Slot)}. " +
                $"Invalid {nameof(item.SlotType)}:{item.SlotType} or {nameof(Slots)} already allocated.");
        }

        public void Unequip(IEquipable item)
        {
            if (EquipedItems.Contains(item))
            {
                var allocatedSlots = Slots.Where(slot => !slot.IsEmpty && slot.Item == item);
                foreach (var slot in allocatedSlots)
                    slot.Item = null!;
                Unequiped?.Invoke(this, new UnequipedEventArgs(item));
            }
            else throw new ArgumentException($"{nameof(item)}:{item.Name} is not equiped.");
        }

        private static bool DoesNotContainDuplicatedTypes(IEnumerable<Slot> slots)
        {
            var numberOfDuplicatedTypes = slots
                .GroupBy(slot => slot.SlotType)
                .Count(group => group.Count() > 1);

            return numberOfDuplicatedTypes == 0;
        }
    }
}