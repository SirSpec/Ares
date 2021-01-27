using GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace GameSystem.Statistics.DerivedStatistics.Offence
{
    public class LightningDamage : ElementalDamage
    {
        public override string Name { get; } = "Lightning Damage";

        public LightningDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}