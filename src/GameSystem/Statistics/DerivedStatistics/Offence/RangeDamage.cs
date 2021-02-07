using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public class RangeDamage : Damage
    {
        public override string Name { get; } = "Range Damage";

        public RangeDamage(Dexterity dexterity) : base(dexterity)
        {
        }
    }
}