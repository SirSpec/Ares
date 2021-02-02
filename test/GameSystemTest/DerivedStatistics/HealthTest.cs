using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Statistics.DerivedStatistics.Energy;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using Xunit;

namespace Ares.GameSystemTest.DerivedStatistics
{
    public class HealthTest
    {
        [Fact]
        public void Value_Default_12()
        {
            //Arrange
            var sut = new Health(new Strength());

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(12, results);
        }

        [Fact]
        public void Value_TwoPointsOfStrength_24()
        {
            //Arrange
            var strength = new Strength();
            var sut = new Health(strength);

            //Act
            strength.SetBaseValue(2);
            var results = sut.Value;

            //Assert
            Assert.Equal(24, results);
        }

        [Fact]
        public void BaseValue_TwoPointsOfStrength_24()
        {
            //Arrange
            var strength = new Strength();
            var sut = new Health(strength);

            //Act
            strength.SetBaseValue(2);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(24, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedValue()
        {
            //Arrange
            var strength = new Strength();
            var sut = new Health(strength);

            //Act
            strength.SetBaseValue(2);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(34, results);
        }

        [Fact]
        public void BaseValue_Enhanced_BaseValueNotChanged()
        {
            //Arrange
            var strength = new Strength();
            var sut = new Health(strength);

            //Act
            strength.SetBaseValue(2);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(24, results);
        }
    }
}