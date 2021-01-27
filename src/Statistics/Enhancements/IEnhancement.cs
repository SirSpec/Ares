using Ares.Statistics.Base;

namespace Ares.Statistics.Enhancements
{
    public interface IEnhancement<out TEnhanceable> where TEnhanceable : class, IStatistic
    {
        int Enhance(int value);
    }
}