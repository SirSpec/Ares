using System;
using Ares.Domain.Constants;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class CoinageBagTest
{
    [Fact]
    public void Constructor_DuplicateCoinsType_ThrowsInvalidOperationException()
    {
        Action action = () => new CoinageBag(new()
        {
            new Coinage(1, PreciousMetal.Copper),
            new Coinage(10, PreciousMetal.Copper)
        });

        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void Constructor_SingleCoinsType_ValidCoinsList()
    {
        var sut = new CoinageBag(new()
        {
            new Coinage(1, PreciousMetal.Copper),
        });

        Assert.Equal(1, sut[PreciousMetal.Copper].Value);
        Assert.Equal(0, sut[PreciousMetal.Silver].Value);
        Assert.Equal(0, sut[PreciousMetal.Electrum].Value);
        Assert.Equal(0, sut[PreciousMetal.Gold].Value);
        Assert.Equal(0, sut[PreciousMetal.Platinum].Value);
    }

    [Fact]
    public void GetIncreasedBy_Empty_NewListWithAdditionalCoins()
    {
        var expected = new Coinage(10, PreciousMetal.Copper);
        var sut = new CoinageBag(new());

        var result = sut.GetIncreasedBy(expected);

        Assert.Equal(expected, result[PreciousMetal.Copper]);
    }

    [Fact]
    public void GetIncreasedBy_AlreadyHasCoins_NewListWithAdditionalCoins()
    {
        var expected = new Coinage(20, PreciousMetal.Copper);
        var sut = new CoinageBag(new()
        {
            new Coinage(10, PreciousMetal.Copper)
        });

        var result = sut.GetIncreasedBy(new Coinage(10, PreciousMetal.Copper));

        Assert.Equal(expected, result[PreciousMetal.Copper]);
    }
}
