using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public class LightningDamage : Damage
    {
        public override string Name { get; } = "Lightning Damage";

        public LightningDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}