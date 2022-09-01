using Ares.Domain.Constants;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class CoinageTest
{
    [Fact]
    public void Coinage_NegativeValue_ThrowDomainException()
    {
        var action = () => new Coinage(-1, PreciousMetal.Copper);

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void AddOperator_IncompatibleCoinage_ThrowDomainException()
    {
        var sut1 = new Coinage(10, PreciousMetal.Copper);
        var sut2 = new Coinage(40, PreciousMetal.Silver);

        var action = () => sut1 + sut2;

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void AddOperator_10Plus40_50()
    {
        var sut1 = new Coinage(10, PreciousMetal.Copper);
        var sut2 = new Coinage(40, PreciousMetal.Copper);

        var actual = sut1 + sut2;

        Assert.Equal(50, actual.Value);
    }

    [Fact]
    public void SubtractOperator_IncompatibleCoinage_ThrowDomainException()
    {
        var sut1 = new Coinage(10, PreciousMetal.Copper);
        var sut2 = new Coinage(10, PreciousMetal.Silver);

        var action = () => sut1 - sut2;

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void SubtractOperator_40Minus10_30()
    {
        var sut1 = new Coinage(40, PreciousMetal.Gold);
        var sut2 = new Coinage(10, PreciousMetal.Gold);

        var actual = sut1 - sut2;

        Assert.Equal(30, actual.Value);
    }
}
