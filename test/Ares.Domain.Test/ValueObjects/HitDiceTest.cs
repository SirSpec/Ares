using System;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class HitDiceTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(-1, 1)]
    public void Constructor_InvalidArgument_ThrowsDomainException(int total, int type)
    {
        Action action = () => new HitDice(total, type);

        Assert.Throws<DomainException>(action);
    }
}
