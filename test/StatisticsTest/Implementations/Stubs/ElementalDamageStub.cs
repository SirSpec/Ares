using Ares.Statistics.Implementations.DerivedStatistics.Offence;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;
using System;

namespace Ares.StatisticsTest.Implementations.Stubs
{
    public class ElementalDamageStub : ElementalDamage
    {
        public override string Name => throw new NotImplementedException();

        public ElementalDamageStub(Intelligence intelligence) : base(intelligence)
        {
        }
    }
}