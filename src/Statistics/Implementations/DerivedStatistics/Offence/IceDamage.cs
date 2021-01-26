using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public class IceDamage : ElementalDamage
    {
        public override string Name { get; } = "Ice Damage";

        public IceDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}