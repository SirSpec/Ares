using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public class FireDamage : Damage
    {
        public override string Name { get; } = "Fire Damage";

        public FireDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}