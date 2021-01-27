using Ares.GameSystemTest.Stubs;
using Ares.Statistics;
using GameSystem.Statistics.DerivedStatistics.Offence;
using GameSystem.Statistics.PrimaryStatistics.Attributes;
using System;
using Xunit;

namespace Ares.GameSystemTest
{
    public class RangeDamageTest
    {
        [Fact]
        public void SetBaseValue_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new RangeDamage(new Dexterity());

            //Act
            Action action = () => sut.SetBaseValue(-1);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_DefaultDexterity_Zero()
        {
            //Arrange
            var sut = new RangeDamage(new Dexterity());

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_DefaultDexterity_Zero()
        {
            //Arrange
            var sut = new RangeDamage(new Dexterity());

            //Act
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_IncreaseDexterityWithDefaultBaseValue_Zero()
        {
            //Arrange
            var dexterity = new Dexterity();
            var sut = new RangeDamage(dexterity);

            //Act
            dexterity.SetBaseValue(10);
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValue_IncreaseDexterityWithDefaultBaseValue_Zero()
        {
            //Arrange
            var dexterity = new Dexterity();
            var sut = new RangeDamage(dexterity);

            //Act
            dexterity.SetBaseValue(10);
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void Value_SetBaseValueToFiveWithDefaultDexterity_Five()
        {
            //Arrange
            var sut = new RangeDamage(new Dexterity());

            //Act
            sut.SetBaseValue(5);
            var results = sut.Value;

            //Assert
            Assert.Equal(5, results);
        }

        [Fact]
        public void BaseValue_SetBaseValueToFiveWithDefaultDexterity_Five()
        {
            //Arrange
            var sut = new RangeDamage(new Dexterity());

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
            var dexterity = new Dexterity();
            var sut = new RangeDamage(dexterity);

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
            var sut = new RangeDamage(new Dexterity());

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
            var dexterity = new Dexterity();
            var sut = new RangeDamage(dexterity);

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
            var sut = new RangeDamage(new Dexterity());

            //Act
            sut.SetBaseValue(1);
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(1, results);
        }
    }
}