using System;

namespace Ares.Progression
{
    public readonly struct Level : IEquatable<Level>
    {
        public const int Minimum = 1;
        public const int Maximum = 100;

        public int Value { get; }
        public bool IsMaximum => Value == Maximum;

        public Level(int level) =>
            Value = level is >= Minimum and <= Maximum
                ? level
                : throw new ArgumentException(
                    $"{nameof(level)}:{level} is not within the range {Minimum} - {Maximum}.");

        public bool Equals(Level other) =>
            Value == other.Value;
    }
}