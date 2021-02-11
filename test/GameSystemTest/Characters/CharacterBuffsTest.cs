using System;
using Ares.GameSystem.Effects;
using Ares.GameSystem.Statistics.PrimaryStatistics.Attributes;
using Ares.GameSystemTest.Stubs;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterBuffsTest
    {
        private Buff TestBuff => new Buff("TestBuff", new StubTypeEnhancement<Strength>(10));

        [Fact]
        public void AddBuff_TestBuff_StatisticBuffed()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();

            //Act
            sut.AddBuff(TestBuff);
            var result = sut.StatisticsSet.GetStatistic<Strength>().Value;

            //Assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void AddBuff_TheSameBuffTwice_ThrowArgumentException()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var testBuff = TestBuff;

            sut.AddBuff(testBuff);

            //Act
            Action action = () => sut.AddBuff(testBuff);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void RemoveBuff_TestBuff_DefaultStatistic()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var testBuff = TestBuff;
            sut.AddBuff(testBuff);

            //Act
            sut.RemoveBuff(testBuff);
            var result = sut.StatisticsSet.GetStatistic<Strength>().Value;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveBuff_NotAddedBuff_ThrowArgumentException()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();

            //Act
            Action action = () => sut.RemoveBuff(TestBuff);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}