using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record Coinage
{
    public const double CoinWeight = 0.02;

    public Coinage(int value, PreciousMetal preciousMetal)
    {
        Value = value >= 0
            ? value
            : throw new DomainException(ErrorCodes.Coinage.InvalidValue, (nameof(value), value));

        PreciousMetal = preciousMetal;
    }

    public int Value { get; }
    public PreciousMetal PreciousMetal { get; }
    public double Weight =>
        Value * CoinWeight;

    public static Coinage operator +(Coinage left, Coinage right) =>
        left.PreciousMetal == right.PreciousMetal
            ? new Coinage(left.Value + right.Value, left.PreciousMetal)
            : throw new DomainException(
                ErrorCodes.Coinage.IncompatibleCoinage,
                (nameof(left), left.PreciousMetal),
                (nameof(right), right.PreciousMetal));

    public static Coinage operator -(Coinage left, Coinage right) =>
        left.PreciousMetal == right.PreciousMetal
            ? new Coinage(left.Value - right.Value, left.PreciousMetal)
            : throw new DomainException(
                ErrorCodes.Coinage.IncompatibleCoinage,
                (nameof(left), left.PreciousMetal),
                (nameof(right), right.PreciousMetal));
}
