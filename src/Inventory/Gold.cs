using System;

namespace Ares.Inventory
{
    public readonly struct Gold : IEquatable<Gold>
    {
        private const int Minimum = 0;

        public int Value { get; }
        public static Gold Zero => new Gold(Minimum);

        public Gold(int value) =>
            Value = value >= Minimum
                ? value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be less than {Minimum}.");

        public static Gold operator +(Gold left, Gold right) =>
            new Gold(left.Value + right.Value);

        public static Gold operator -(Gold left, Gold right) =>
            new Gold(left.Value - right.Value);

        public bool Equals(Gold other) =>
            Value == other.Value;
    }
}