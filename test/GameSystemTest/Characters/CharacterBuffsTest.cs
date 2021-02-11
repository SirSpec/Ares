using System;
using Ares.GameSystem.Effects;
using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;
using Ares.GameSystemTest.Stubs;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterBuffsTest
    {
        [Fact]
        public void AddBuff_TestBuff_StatisticBuffed()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new Buff("TestBuff", new StubTypeEnhancement<Strength>(10));

            //Act
            sut.AddBuff(damage);
            var result = sut.StatisticsSet.GetStatistic<Strength>().Value;

            //Assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void AddBuff_TheSameBuffTwice_ThrowArgumentException()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new Buff("TestBuff", new StubTypeEnhancement<Strength>(10));
            sut.AddBuff(damage);

            //Act
            Action action = () => sut.AddBuff(damage);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void RemoveBuff_TestBuff_DefaultStatistic()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new Buff("TestBuff", new StubTypeEnhancement<Strength>(10));
            sut.AddBuff(damage);

            //Act
            sut.RemoveBuff(damage);
            var result = sut.StatisticsSet.GetStatistic<Strength>().Value;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveBuff_NotAddedBuff_ThrowArgumentException()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new Buff("TestBuff", new StubTypeEnhancement<Strength>(10));

            //Act
            Action action = () => sut.RemoveBuff(damage);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}