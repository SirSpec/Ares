using System;
using System.Collections.Generic;
using Ares.Statistics.Enhancements;

namespace Ares.Statistics.Base
{
    public interface IEnhanceable
    {
        public IList<IEnhancement> Enhancements { get; }

        public void AddEnhancement(IEnhancement enhancement)
        {
            if (!Enhancements.Contains(enhancement)) Enhancements.Add(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} already exists.");
        }

        public void RemoveEnhancement(IEnhancement enhancement)
        {
            if (Enhancements.Contains(enhancement)) Enhancements.Remove(enhancement);
            else throw new InvalidOperationException($"{nameof(enhancement)}:{enhancement} does not exist.");
        }
    }
}