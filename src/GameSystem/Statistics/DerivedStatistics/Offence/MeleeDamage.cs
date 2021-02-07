using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;

namespace Ares.GameSystem.Statistics.DerivedStatistics.Offence
{
    public class MeleeDamage : Damage
    {
        public override string Name { get; } = "Melee Damage";

        public MeleeDamage(Strength strength) : base(strength)
        {
        }
    }
}