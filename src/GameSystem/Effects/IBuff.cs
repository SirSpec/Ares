using Ares.Spells.Effects;
using Ares.Statistics;

namespace Ares.GameSystem.Effects
{
    public interface IBuff : IEffect
    {
        IEnhancement<IStatistic> Enhancement { get; }
    }
}