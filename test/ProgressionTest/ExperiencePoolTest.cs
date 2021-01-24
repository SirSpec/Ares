using System;
using Ares.Progression;
using Xunit;

namespace Ares.ProgressionTest
{
    public class ExperiencePoolTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new ExperiencePool(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_ExceedsMaxPoints_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new ExperiencePool(ExperiencePool.Maximum + 1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_Zero_LevelOne()
        {
            //Arrange
            var sut = new ExperiencePool(0);

            //Act
            var result = sut.Level;

            //Assert
            Assert.Equal(Level.Minimum, result.Value);
        }

        [Fact]
        public void Constructor_MaxExperiencePoints_MaxLevel()
        {
            //Arrange
            var sut = new ExperiencePool(ExperiencePool.Maximum);

            //Act
            var result = sut.Level.Value;

            //Assert
            Assert.Equal(Level.Maximum, result);
        }

        [Fact]
        public void Gain_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            var sut = new ExperiencePool(0);

            //Act
            Action result = () => sut.Gain(-1);

            //Assert
            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void Gain_NotEnoughExperiencePoints_TheSameLevel()
        {
            //Arrange
            var result = 1;
            var points = 10;
            var sut = new ExperiencePool(0);
            sut.LeveledUp += (_, level) => result = level.Value;

            //Act
            sut.Gain(points);

            //Assert
            Assert.Equal(Level.Minimum, result);
            Assert.Equal(Level.Minimum, sut.Level.Value);
        }

        [Fact]
        public void LeveledUpEvent_SecondLevelExperience_EventTriggered()
        {
            //Arrange
            var result = 0;
            var levelTwoExperience = 100;
            var sut = new ExperiencePool(0);
            sut.LeveledUp += (_, level) => result = level.Value;

            //Act
            sut.Gain(levelTwoExperience);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Gain_MaxLevelExperience_MaxLevel()
        {
            //Arrange
            var sut = new ExperiencePool(0);

            //Act
            sut.Gain(ExperiencePool.Maximum);

            //Assert
            Assert.Equal(Level.Maximum, sut.Level.Value);
            Assert.Equal(ExperiencePool.Maximum, sut.Points);
        }

        [Fact]
        public void Gain_MoreThanMaxLevelExperience_MaxLevel()
        {
            //Arrange
            var sut = new ExperiencePool(0);

            //Act
            sut.Gain(ExperiencePool.Maximum + 1);
            sut.Gain(1);

            //Assert
            Assert.Equal(Level.Maximum, sut.Level.Value);
            Assert.Equal(ExperiencePool.Maximum, sut.Points);
        }
    }
}