namespace Ares.Inventory
{
    public interface IItem
    {
        string Name { get; }
        Weight Weight { get; }
    }
}