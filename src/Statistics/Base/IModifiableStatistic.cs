namespace Ares.Statistics.Base
{
    public interface IModifiableStatistic : IStatistic
    {
        void SetBaseValue(int value);
    }
}