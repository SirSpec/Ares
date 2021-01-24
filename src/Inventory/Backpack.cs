using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Inventory
{
    public class Backpack
    {
        private const int MinimumCapacity = 0;
        private readonly IList<IItem> items;

        public int Capacity { get; }
        public IEnumerable<IItem> Items => items;
        public bool IsFull => Items.Count() == Capacity;
        public Weight Weight => Items.Aggregate(Weight.Zero, (seed, next) => seed += next.Weight);

        public Backpack(int capacity)
        {
            if (capacity < MinimumCapacity)
                throw new ArgumentException($"{nameof(capacity)}:{capacity} cannot be less than {MinimumCapacity}.");

            (items, Capacity) = (new List<IItem>(), capacity);
        }

        public bool Contains(IItem item) =>
            Items.Contains(item);

        public void Put(IItem item)
        {
            if (!IsFull && !items.Contains(item)) items.Add(item);
            else throw new InvalidOperationException(
                $"{nameof(Backpack)} of {nameof(Capacity)}:{Capacity} is already full or {nameof(item)}:{item} already added.");
        }

        public void Remove(IItem item)
        {
            if (items.Contains(item)) items.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}