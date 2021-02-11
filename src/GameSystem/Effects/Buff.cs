using Ares.Statistics;

namespace Ares.GameSystem.Effects
{
    public class Buff : IBuff
    {
        public string Name { get; }
        public IEnhancement<IStatistic> Enhancement { get; }

        public Buff(string name, IEnhancement<IStatistic> enhancement) =>
            (Name, Enhancement) = (name, enhancement);
    }
}