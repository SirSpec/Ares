using System;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class DeathSavesTest
{
    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(4, 0)]
    [InlineData(0, 4)]
    public void Constructor_ValuesNotInRange_ThrowsDomainException(int successes, int failures)
    {
        Action action = () => new DeathSaves(successes, failures);

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Constructor_ValuesInRange_ValidValues()
    {
        var sut = new DeathSaves(1, 3);

        (var actualSuccesses, var actualFailures) = sut;

        Assert.Equal(1, actualSuccesses);
        Assert.Equal(3, actualFailures);
    }
}
