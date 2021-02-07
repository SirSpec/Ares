using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using Ares.GameSystem.Statistics.PrimaryStatistics.Defence;
using Xunit;

namespace Ares.GameSystemTest.PrimaryStatistics
{
    public class ResistanceTest
    {
        [Fact]
        public void Value_Default_Minimum()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Minimum, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedValue()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(9));
            var results = sut.Value;

            //Assert
            Assert.Equal(9, results);
        }

        [Fact]
        public void BaseValue_Enhanced_BaseValueNotChanged()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(9));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(Resistance.Minimum, results);
        }

        [Fact]
        public void Value_EnhancedMoreThanMaximum_Maximum()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(Resistance.Maximum + 1));
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Maximum, results);
        }

        [Fact]
        public void Value_EnhancedBelowMinimum_Minumum()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(-1));
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Minimum, results);
        }
    }
}