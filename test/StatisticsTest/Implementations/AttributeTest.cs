using System;
using Ares.Statistics.Base;
using Ares.StatisticsTest.Implementations.Stubs;
using Ares.StatisticsTest.Stubs;
using Xunit;

namespace Ares.StatisticsTest.Implementations
{
    public class AttributeTest
    {
        [Fact]
        public void SetBaseValue_Zero_ArgumentException()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            Action action = () => sut.SetBaseValue(0);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_Default_One()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(1, results);
        }

        [Fact]
        public void SetBaseValue_Two_ValueEqualsTwo()
        {
            //Arrange
            var expectedValue = 2;
            var sut = new AttributeStub();

            //Act
            sut.SetBaseValue(expectedValue);
            var results = sut.Value;

            //Assert
            Assert.Equal(expectedValue, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedValue()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.Value;

            //Assert
            Assert.Equal(11, results);
        }

        [Fact]
        public void BaseValue_Enhanced_BaseValueNotChanged()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            ((IEnhanceable)sut).AddEnhancement(new StubEnhancement(10));
            var results = sut.BaseValue;

            //Assert
            Assert.Equal(1, results);
        }
    }
}