using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;

namespace Ares.Statistics.Implementations.DerivedStatistics.Offence
{
    public class FireDamage : ElementalDamage
    {
        public override string Name { get; } = "Fire Damage";

        public FireDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}