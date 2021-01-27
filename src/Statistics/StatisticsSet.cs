using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Statistics
{
    public class StatisticsSet
    {
        private readonly IEnumerable<IStatistic> statistics;

        public StatisticsSet(IEnumerable<IStatistic> statistics) =>
            this.statistics = DoesNotContainDuplicatedTypes(statistics)
                ? statistics
                : throw new ArgumentException($"{nameof(statistics)} contains duplicated types of statistics.");

        public IEnumerable<TStatistic> GetStatistics<TStatistic>() where TStatistic : IStatistic =>
            FindStatistics(typeof(TStatistic)).Select(statistic => (TStatistic)statistic);

        public TStatistic GetStatistic<TStatistic>() where TStatistic : IStatistic =>
            (TStatistic)FindStatistics(typeof(TStatistic)).Single();

        public void Apply(params IEnhancement<IStatistic>[] enhancements)
        {
            foreach (var enhancement in enhancements)
            {
                var statisticType = enhancement.GetType().GenericTypeArguments.Single();
                var enhanceableStatistic = FindStatistics(statisticType).Single() as IEnhanceable;

                if (enhanceableStatistic is not null)
                    enhanceableStatistic.AddEnhancement(enhancement);
                else throw new InvalidOperationException($"{enhanceableStatistic} is not {nameof(IEnhanceable)} type");
            }
        }

        public void Remove(params IEnhancement<IStatistic>[] enhancements)
        {
            foreach (var enhancement in enhancements)
            {
                var statisticType = enhancement.GetType().GenericTypeArguments.Single();
                var enhanceableStatistic = FindStatistics(statisticType).Single() as IEnhanceable;

                if (enhanceableStatistic is not null)
                    enhanceableStatistic.RemoveEnhancement(enhancement);
                else throw new InvalidOperationException($"{enhanceableStatistic} is not {nameof(IEnhanceable)} type");
            }
        }

        private IEnumerable<IStatistic> FindStatistics(Type type) =>
            statistics.Where(statistic => type.IsAssignableFrom(statistic.GetType()));

        private static bool DoesNotContainDuplicatedTypes(IEnumerable<IStatistic> statistics)
        {
            var numberOfDuplicatedTypes = statistics
                .GroupBy(statistic => statistic.GetType())
                .Count(group => group.Count() > 1);

            return numberOfDuplicatedTypes == 0;
        }
    }
}
