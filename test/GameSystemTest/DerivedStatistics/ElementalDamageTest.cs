using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using System;
using Xunit;

namespace Ares.GameSystemTest.DerivedStatistics
{
    public class ElementalDamageTest
    {
        [Fact]
        public void SetBaseValue_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            Action action = () => sut.SetBaseValue(-1);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_DefaultIntelligence_Zero()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_DefaultIntelligence_Zero()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_IncreaseIntelligenceWithDefaultBaseValue_Zero()
        {
            //Arrange
            var intelligence = new Intelligence();
            var sut = new ElementalDamageStub(intelligence);

            //Act
            intelligence.SetBaseValue(10);
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_IncreaseIntelligenceWithDefaultBaseValue_Zero()
        {
            //Arrange
            var intelligence = new Intelligence();
            var sut = new ElementalDamageStub(intelligence);

            //Act
            intelligence.SetBaseValue(10);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_SetBaseValueToFiveWithDefaultIntelligence_Five()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            sut.SetBaseValue(5);
            var results = sut.Value;

            //Assert
            Assert.Equal(5, results);
        }

        [Fact]
        public void BaseValue_SetBaseValueToFiveWithDefaultIntelligence_Five()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            sut.SetBaseValue(5);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(5, results);
        }

        [Fact]
        public void Value_EnhancedWithDefault_Zero()
        {
            //Arrange
            var intelligence = new Intelligence();
            var sut = new ElementalDamageStub(intelligence);

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_EnhancedWithDefault_Zero()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_EnhancedWithBaseValueSetToOne_Enhanced()
        {
            //Arrange
            var intelligence = new Intelligence();
            var sut = new ElementalDamageStub(intelligence);

            //Act
            sut.SetBaseValue(1);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(11, results);
        }

        [Fact]
        public void BaseValue_EnhancedWithBaseValueSetToOne_NotChanged()
        {
            //Arrange
            var sut = new ElementalDamageStub(new Intelligence());

            //Act
            sut.SetBaseValue(1);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(1, results);
        }
    }
}