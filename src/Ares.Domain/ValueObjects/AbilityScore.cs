using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record AbilityScore
{
    public int Value { get; }
    public int Modifier =>
        (int)Math.Floor((double)(Value - 10) / 2);

    public AbilityScore(int value) =>
        Value = value >= 1 && value <= 30
            ? value
            : throw new DomainException(ErrorCodes.AbilityScore.InvalidValue, (nameof(value), value));

    public void Deconstruct(out int value, out int modifier)
    {
        value = Value;
        modifier = Modifier;
    }
}
