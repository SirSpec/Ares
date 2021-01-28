using System;

namespace GameSystem.Weapons
{
    public readonly struct DamageDealt
    {
        private const int Minimum = 0;

        public int Value { get; }
        public DamageType Type { get; }

        public DamageDealt(int value, DamageType type) =>
            (Value, Type) = value >= Minimum
                ? (value, type)
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");
    }
}