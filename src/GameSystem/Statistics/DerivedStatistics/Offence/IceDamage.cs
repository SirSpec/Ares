using GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace GameSystem.Statistics.DerivedStatistics.Offence
{
    public class IceDamage : Damage
    {
        public override string Name { get; } = "Ice Damage";

        public IceDamage(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}