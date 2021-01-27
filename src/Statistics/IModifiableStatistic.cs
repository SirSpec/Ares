namespace Ares.Statistics
{
    public interface IModifiableStatistic : IStatistic
    {
        void SetBaseValue(int value);
    }
}