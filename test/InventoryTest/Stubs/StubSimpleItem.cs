using System;
using Ares.Inventory;

namespace Ares.InventoryTest.Stubs
{
    public class StubSimpleItem : IItem
    {
        public string Name => "StubSimpleItem";
        public Weight Weight { get; } = new Weight(new Random().Next(1, 5));
    }
}