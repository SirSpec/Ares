using System;
using System.Collections.Generic;
using Ares.Inventory;
using Ares.Statistics;

namespace Ares.InventoryTest.Stubs
{
    public class EquipableItemStub : IEquipable
    {
        public string Name => "EquipableItemStub";

        public Weight Weight { get; } = new Weight(new Random().Next(1, 5));

        public Enum SlotType { get; }

        public IEnumerable<IEnhancement<IStatistic>> Enhancements => throw new NotImplementedException();

        public EquipableItemStub() =>
            SlotType = SlotTypeStub.Slot1;

        public EquipableItemStub(Weight weight) : this() =>
            Weight = weight;

        public EquipableItemStub(Enum slotType) =>
            SlotType = slotType;
    }
}