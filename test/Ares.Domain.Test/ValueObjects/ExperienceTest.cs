using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class ExperienceTest
{
    [Theory]
    [InlineData(-1)]
    [InlineData(355001)]
    public void Experience_InvalidValue_ThrowsDomainException(int experience)
    {
        var action = () => new Experience(experience);

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(0, 100, 100)]
    [InlineData(100, 1000, 1100)]
    public void IncreasedBy_GainPoints_MorePoints(int initial, int additional, int expected)
    {
        var sut = new Experience(initial);

        var actual = sut.IncreasedBy(new Experience(additional));

        Assert.Equal(expected, actual);
    }
}
