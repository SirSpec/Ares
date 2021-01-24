using System;
using Ares.Progression;
using Xunit;

namespace Ares.ProgressionTest
{
    public class LevelTest
    {
        [Fact]
        public void Constructor_InputBelowMinimumLevel_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new Level(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_InputAboveMaximumLevel_ThrowsArgumentException()
        {
            //Arrange Act
            Action sut = () => new Level(Level.Maximum + 1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_InputEdgeCase_ValidObjects()
        {
            //Arrange
            var sut1 = new Level(Level.Minimum);
            var sut2 = new Level(Level.Maximum);

            //Act
            var result1 = sut1;
            var result2 = sut2;

            //Assert
            Assert.Equal(Level.Minimum, result1.Value);
            Assert.Equal(Level.Maximum, result2.Value);

            Assert.False(result1.IsMaximum);
            Assert.True(result2.IsMaximum);
        }
    }
}