namespace Ares.GameSystem.Effects
{
    public class DefensiveInstant : IInstant<int>
    {
        public string Name { get; }
        public int Value { get; }

        public DefensiveInstant(string name, int value) =>
            (Name, Value) = (name, value);
    }
}