using System;
using System.Collections.Generic;

namespace Ares.Statistics
{
    public interface IEnhanceable
    {
        IList<IEnhancement<IStatistic>> Enhancements { get; }

        public void AddEnhancement(IEnhancement<IStatistic> enhancement)
        {
            if (!Enhancements.Contains(enhancement)) Enhancements.Add(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} already exists.");
        }

        public void RemoveEnhancement(IEnhancement<IStatistic> enhancement)
        {
            if (Enhancements.Contains(enhancement)) Enhancements.Remove(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} does not exist.");
        }
    }
}