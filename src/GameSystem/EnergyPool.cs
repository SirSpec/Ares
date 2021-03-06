﻿using System;

namespace Ares.GameSystem
{
    public class EnergyPool
    {
        private const int Minimum = 0;

        public int Current { get; private set; }
        public int Total { get; }

        public EnergyPool(int total) =>
            (Current, Total) = total < Minimum
                ? throw new ArgumentException($"{nameof(total)}:{total} cannot be negative.")
                : (total, total);

        public EnergyPool(int current, int total) =>
            (Current, Total) = current < Minimum || total < Minimum || current > total
                ? throw new ArgumentException($"{nameof(current)}:{current} and {nameof(total)}:{total} are invalid.")
                : (current, total);

        public void Increase(int value) =>
            Current = value > Minimum
                ? Current + value >= Total
                    ? Total
                    : Current + value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");

        public void Decrease(int value) =>
            Current = value > Minimum
                ? Current - value <= Minimum
                    ? Minimum
                    : Current - value
                : throw new ArgumentException($"{nameof(value)}:{value} cannot be negative.");
    }
}