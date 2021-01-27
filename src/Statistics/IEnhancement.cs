namespace Ares.Statistics
{
    public interface IEnhancement<out TEnhanceable> where TEnhanceable : class, IStatistic
    {
        int Enhance(int value);
    }
}