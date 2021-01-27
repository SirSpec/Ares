﻿using System;

namespace Ares.Inventory.Implementations.Armor
{
    public readonly struct ArmorValue
    {
        private const int Minimum = 0;

        public int Value { get; }

        public ArmorValue(int value) =>
            Value = value >= Minimum
                ? value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
    }
}