using Ares.Spells.Effects;

namespace Ares.GameSystem.Effects
{
    public interface IInstant<TValue> : IEffect
    {
        TValue Value { get; }
    }
}