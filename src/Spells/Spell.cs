using Ares.Spells.Effects;

namespace Ares.Spells
{
    public readonly struct Spell
    {
        public string Name { get; }
        public IEffect Effect { get; }
        public int Cost { get; }

        public Spell(string name, IEffect effect, int cost) =>
            (Name, Effect, Cost) = (name, effect, cost);
    }
}