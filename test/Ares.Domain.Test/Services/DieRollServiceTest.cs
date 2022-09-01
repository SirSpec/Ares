using Ares.Domain.Exceptions;
using Ares.Domain.Services;
using Xunit;

namespace Ares.Domain.Test.Services;

public class DieRollServiceTest
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void RollDie_InvalidType_ThrowsDomainException(int type)
    {
        var sut = new DieRollService(new RandomAdapter());

        var action = () => sut.RollDie(type);

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void RollDice_LessThanOne_ThrowsDomainException(int count)
    {
        var sut = new DieRollService(new RandomAdapter());

        var action = () => sut.RollDice(count, 20);

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void RollDice_3d20_3d20()
    {
        var expectedType = 20;
        var expectedLength = 3;
        var sut = new DieRollService(new RandomAdapter());

        var result = sut.RollDice(expectedLength, expectedType);

        Assert.Equal(expectedLength, result.Length);

        for (int i = 0; i < expectedLength; i++)
            Assert.Equal(expectedType, result[i].Type);
    }
}
