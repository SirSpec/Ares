using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Statistics.DerivedStatistics.Offence;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using System;
using Xunit;

namespace Ares.GameSystemTest.DerivedStatistics
{
    public class MeleeDamageTest
    {
        [Fact]
        public void SetBaseValue_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new MeleeDamage(new Strength());

            //Act
            Action action = () => sut.SetBaseValue(-1);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_DefaultStrength_Zero()
        {
            //Arrange
            var sut = new MeleeDamage(new Strength());

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_DefaultStrength_Zero()
        {
            //Arrange
            var sut = new MeleeDamage(new Strength());

            //Act
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_IncreaseStrengthWithDefaultBaseValue_Zero()
        {
            //Arrange
            var strength = new Strength();
            var sut = new MeleeDamage(strength);

            //Act
            strength.SetBaseValue(10);
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_IncreaseStrengthWithDefaultBaseValue_Zero()
        {
            //Arrange
            var strength = new Strength();
            var sut = new MeleeDamage(strength);

            //Act
            strength.SetBaseValue(10);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_SetBaseValueToFiveWithDefaultStrength_Five()
        {
            //Arrange
            var sut = new MeleeDamage(new Strength());

            //Act
            sut.SetBaseValue(5);
            var results = sut.Value;

            //Assert
            Assert.Equal(5, results);
        }

        [Fact]
        public void BaseValue_SetBaseValueToFiveWithDefaultStrength_Five()
        {
            //Arrange
            var sut = new MeleeDamage(new Strength());

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
            var strength = new Strength();
            var sut = new MeleeDamage(strength);

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
            var sut = new MeleeDamage(new Strength());

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
            var strength = new Strength();
            var sut = new MeleeDamage(strength);

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
            var sut = new MeleeDamage(new Strength());

            //Act
            sut.SetBaseValue(1);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(1, results);
        }
    }
}