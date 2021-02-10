using Ares.Spells;
using Ares.Spells.Effects;

namespace Ares.GameSystem
{
    public interface ICaster
    {
        IEffect Cast(Spell spell);
    }
}