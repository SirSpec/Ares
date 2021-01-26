using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public class LightningDamage : ElementalDamage
    {
        public override string Name { get; } = "Lightning Damage";

        public LightningDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}