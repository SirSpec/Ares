﻿using System;

namespace Ares.Inventory.Implementations.Weapons
{
    public readonly struct DamageDealt
    {
        private const int Minimum = 0;

        public int Value { get; }
        public Enum Type { get; }

        public DamageDealt(int value, Enum type) =>
            (Value, Type) = value >= Minimum
                ? (value, type)
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
    }
}