using System;
using System.Collections.Generic;
using Ares.Statistics;

namespace Ares.Inventory
{
    public interface IEquipable : IItem
    {
        Enum SlotType { get; }
        IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }
    }
}