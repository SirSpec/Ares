using GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace GameSystem.Statistics.DerivedStatistics.Offence
{
    public class FireDamage : ElementalDamage
    {
        public override string Name { get; } = "Fire Damage";

        public FireDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}