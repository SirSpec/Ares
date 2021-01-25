using Ares.Statistics.Base;
using Ares.Statistics.Implementations.DerivedStatistics.Energy;
using Ares.Statistics.Implementations.PrimaryStatistics.Attributes;
using Ares.StatisticsTest.Stubs;
using Xunit;

namespace Ares.StatisticsTest.Implementations
{
    public class ManaTest
    {
        [Fact]
        public void Value_Default_6()
        {
            //Arrange
            var sut = new Mana(new Intelligence());

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(6, results);
        }

        [Fact]
        public void Value_TwoPointsOfIntelligence_8()
        {
            //Arrange
            var inteligence = new Intelligence();
            var sut = new Mana(inteligence);

            //Act
            inteligence.SetBaseValue(2);
            var results = sut.Value;

            //Assert
            Assert.Equal(12, results);
        }

        [Fact]
        public void BaseValue_TwoPointsOfIntelligence_8()
        {
            //Arrange
            var inteligence = new Intelligence();
            var sut = new Mana(inteligence);

            //Act
            inteligence.SetBaseValue(2);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(12, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedValue()
        {
            //Arrange
            var inteligence = new Intelligence();
            var sut = new Mana(inteligence);

            //Act
            inteligence.SetBaseValue(2);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(22, results);
        }

        [Fact]
        public void BaseValue_Enhanced_BaseValueNotChanged()
        {
            //Arrange
            var inteligence = new Intelligence();
            var sut = new Mana(inteligence);

            //Act
            inteligence.SetBaseValue(2);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(12, results);
        }
    }
}