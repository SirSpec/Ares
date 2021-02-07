using System;

namespace Ares.GameSystem
{
    [Flags]
    public enum SlotType
    {
        Helmet = 1,
        Chest = 2,
        MainHand = 4,
        OffHand = 8,
        Gloves = 16,
        Boots = 32
    }
}