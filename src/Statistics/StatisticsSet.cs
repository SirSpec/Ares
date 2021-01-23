using System;
using System.Collections.Generic;
using System.Linq;
using Ares.Statistics.Base;

namespace Ares.Statistics
{
    public class StatisticsSet
    {
        private readonly IEnumerable<IStatistic> statistics;

        public StatisticsSet(IEnumerable<IStatistic> statistics)
        {
            if (ContainsDuplicatedTypes(statistics))
                throw new ArgumentException("Collection contains duplicated types of statistics.");

            this.statistics = statistics;
        }

        public IEnumerable<TStatistic> GetStatistics<TStatistic>() where TStatistic : IStatistic =>
            FindStatistics(typeof(TStatistic))
                .Select(statistic => (TStatistic)statistic);

        public TStatistic GetStatistic<TStatistic>() where TStatistic : IStatistic =>
            (TStatistic)FindStatistics(typeof(TStatistic))
                .Single();

        private IEnumerable<IStatistic> FindStatistics(Type type) =>
            statistics.Where(statistic => type.IsAssignableFrom(statistic.GetType()));

        private static bool ContainsDuplicatedTypes(IEnumerable<IStatistic> statistics)
        {
            var numberOfDuplicatedTypes = statistics
                .GroupBy(statistic => statistic.GetType())
                .Count(group => group.Count() > 1);

            return numberOfDuplicatedTypes != 0;
        }
    }
}
