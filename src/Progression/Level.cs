using System;

namespace Ares.Progression
{
    public readonly struct Level : IEquatable<Level>
    {
        public const int Minimum = 1;
        public const int Maximum = 100;

        public int Value { get; }
        public bool IsMaximum => Value == Maximum;

        public Level(int level)
        {
            if (level < Minimum || level > Maximum)
                throw new ArgumentException($"{nameof(level)}:{level} is not within the range {Minimum} - {Maximum}.");

            Value = level;
        }

        public bool Equals(Level other) =>
            Value == other.Value;
    }
}