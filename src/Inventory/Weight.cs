using System;

namespace Ares.Inventory
{
    public readonly struct Weight : IEquatable<Weight>
    {
        private const int Minimum = 0;
        public int Value { get; }
        public static Weight Zero => new Weight(Minimum);

        public Weight(int value) =>
            Value = value >= Minimum
                ? value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

        public static Weight operator +(Weight left, Weight right) =>
            new Weight(left.Value + right.Value);

        public static Weight operator -(Weight left, Weight right) =>
            new Weight(left.Value - right.Value);

        public static bool operator <=(Weight left, Weight right) =>
            left.Value <= right.Value;

        public static bool operator >=(Weight left, Weight right) =>
            left.Value >= right.Value;

        public bool Equals(Weight other) =>
            Value == other.Value;
    }
}