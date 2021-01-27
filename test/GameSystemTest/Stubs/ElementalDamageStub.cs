using GameSystem.Statistics.DerivedStatistics.Offence;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using System;

namespace Ares.GameSystemTest.Stubs
{
    public class ElementalDamageStub : ElementalDamage
    {
        public override string Name => throw new NotImplementedException();

        public ElementalDamageStub(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}