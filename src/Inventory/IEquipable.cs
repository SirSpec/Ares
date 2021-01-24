namespace Ares.Inventory
{
    public interface IEquipable : IItem
    {
        SlotType SlotType { get; }
    }
}