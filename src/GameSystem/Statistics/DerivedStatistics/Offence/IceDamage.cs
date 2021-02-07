using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public class IceDamage : Damage
    {
        public override string Name { get; } = "Ice Damage";

        public IceDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}