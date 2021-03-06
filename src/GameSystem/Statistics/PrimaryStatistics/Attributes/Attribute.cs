﻿using Ares.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.GameSystem.Statistics.PrimaryStatistics.Attributes
{
    public abstract class Attribute : IModifiableStatistic, IEnhanceable
    {
        private const int Minimum = 1;
        private int baseValue;

        public abstract string Name { get; }

        public int BaseValue => baseValue;
        public int Value => BaseValue + Enhancements.Sum(Enhancement => Enhancement.Enhance(BaseValue));
        public IList<IEnhancement<IStatistic>> Enhancements { get; }

        public Attribute() : this(Minimum, new List<IEnhancement<IStatistic>>())
        {
        }

        public Attribute(int baseValue, IList<IEnhancement<IStatistic>> enhancements)
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