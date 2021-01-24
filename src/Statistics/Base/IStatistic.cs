namespace Ares.Statistics.Base
{
    public interface IStatistic
    {
        string Name { get; }
        int BaseValue { get; }
        int Value { get; }
    }
}