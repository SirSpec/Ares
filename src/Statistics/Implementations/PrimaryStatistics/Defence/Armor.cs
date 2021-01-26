﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;
using Ares.Statistics.Enhancements;

namespace Ares.Statistics.Implementations.PrimaryStatistics.Defence
{
    public class Armor : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 0;
        private int baseValue;

        public string Name { get; } = "Armor";
        public int BaseValue => baseValue;
        public int Value => BaseValue + Enhancements.Sum(enhancement => enhancement.Enhance(BaseValue));
        public IList<IEnhancement> Enhancements { get; }

        public Armor() : this(Minimum, new List<IEnhancement>())
        {
        }

        public Armor(int baseValue, IList<IEnhancement> enhancements)
        {
            SetBaseValue(baseValue);
            Enhancements = enhancements;
        }

        public void SetBaseValue(int baseValue) =>
            this.baseValue = baseValue >= Minimum
                ? baseValue
                : throw new ArgumentException($"{nameof(baseValue)}:{baseValue} cannot be less than {Minimum}.");
    }
}