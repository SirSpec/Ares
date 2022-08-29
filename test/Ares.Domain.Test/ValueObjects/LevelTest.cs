using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class LevelTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(21)]
    public void Level_InvalidValue_ThrowsDomainException(int level)
    {
        var action = () => new Level(level);

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(300, 2)]
    [InlineData(900, 3)]
    [InlineData(2700, 4)]
    [InlineData(6500, 5)]
    [InlineData(14000, 6)]
    [InlineData(23000, 7)]
    [InlineData(34000, 8)]
    [InlineData(48000, 9)]
    [InlineData(64000, 10)]
    [InlineData(85000, 11)]
    [InlineData(100000, 12)]
    [InlineData(120000, 13)]
    [InlineData(140000, 14)]
    [InlineData(165000, 15)]
    [InlineData(195000, 16)]
    [InlineData(225000, 17)]
    [InlineData(265000, 18)]
    [InlineData(305000, 19)]
    [InlineData(355000, 20)]
    public void Level_ValidLevel_ValidTier(int experience, int expectedLevel)
    {
        var sut = new Level(new Experience(experience));

        Assert.Equal(expectedLevel, sut);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 1)]
    [InlineData(5, 2)]
    [InlineData(10, 2)]
    [InlineData(11, 3)]
    [InlineData(16, 3)]
    [InlineData(17, 4)]
    [InlineData(20, 4)]
    public void Tier_ValidLevel_ValidTier(int level, int expectedTier)
    {
        var sut = new Level(level);

        var actual = sut.Tier;

        Assert.Equal(expectedTier, actual);
    }
}
