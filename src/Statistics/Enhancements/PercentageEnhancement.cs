﻿using Ares.Statistics.Base;

namespace Ares.Statistics.Enhancements
{
    public class PercentageEnhancement<TStatistic> : IEnhancement<TStatistic> where TStatistic : class, IStatistic
    {
        private readonly int percentage;

        public PercentageEnhancement(int percentage) =>
            this.percentage = percentage;

        public int Enhance(int value) => value * percentage / 100;
    }
}