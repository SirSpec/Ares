namespace Ares.Statistics
{
    public interface IStatistic
    {
        string Name { get; }
        int BaseValue { get; }
        int Value { get; }
    }
}