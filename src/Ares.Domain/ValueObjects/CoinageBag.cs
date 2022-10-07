using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record CoinageBag
{
    private readonly Dictionary<PreciousMetal, Coinage> _coinageBag;

    public CoinageBag(List<Coinage> coinageList)
    {
        _coinageBag = new Dictionary<PreciousMetal, Coinage>();

        foreach (var preciousMetal in Enum.GetValues<PreciousMetal>())
        {
            var coinage = coinageList.SingleOrDefault(
                coinage => coinage.PreciousMetal == preciousMetal,
                defaultValue: new Coinage(0, preciousMetal)
            );

            _coinageBag.Add(preciousMetal, coinage);
        }
    }

    private CoinageBag(Dictionary<PreciousMetal, Coinage> coinageBag) =>
        _coinageBag = Enum.GetValues<PreciousMetal>().Except(coinageBag.Keys).Any() is false
            ? coinageBag
            : throw new DomainException(ErrorCodes.CoinageBag.InvalidDictionaryKeys, (nameof(coinageBag), coinageBag));

    public Coinage this[PreciousMetal preciousMetal] =>
        _coinageBag[preciousMetal];

    public CoinageBag GetIncreasedBy(Coinage coinage)
    {
        var coinageBag = new Dictionary<PreciousMetal, Coinage>(_coinageBag);
        coinageBag[coinage.PreciousMetal] += coinage;
        return new CoinageBag(coinageBag);
    }

    public CoinageBag GetDecreasedBy(Coinage coinage)
    {
        var coinageBag = new Dictionary<PreciousMetal, Coinage>(_coinageBag);
        coinageBag[coinage.PreciousMetal] -= coinage;
        return new CoinageBag(coinageBag);
    }
}
