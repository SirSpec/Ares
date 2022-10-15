using System;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class HitPointsTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(5, -1, 0)]
    [InlineData(5, 6, 0)]
    [InlineData(5, 5, -1)]
    public void Constructor_InvalidArgument_ThrowsDomainException(int maximum, int current, int temporary)
    {
        Action action = () => new HitPoints(maximum, current, temporary);

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(5, 5, 0, 5)]
    [InlineData(5, 5, 1, 6)]
    [InlineData(5, 3, 0, 3)]
    [InlineData(5, 3, 1, 4)]
    public void Total_ValidArguments_ValidTotal(int maximum, int current, int temporary, int expectedTotal)
    {
        var sut = new HitPoints(maximum, current, temporary);

        int actualTotal = sut;

        Assert.Equal(expectedTotal, actualTotal);
    }
}
