using Ares.GameSystem.Weapons;

namespace Ares.GameSystem.Effects
{
    public class OffensiveInstant : IInstant<DamageDealt>
    {
        public string Name { get; }
        public DamageDealt Value { get; }

        public OffensiveInstant(string name, DamageDealt damage) =>
            (Name, Value) = (name, damage);
    }
}