using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record DieRoll
{
    public int Value { get; }
    public int Type { get; }

    public DieRoll(int value, uint type)
    {
        Value = value >= 1 && value <= type
            ? (int)value
            : throw new DomainException(ErrorCodes.DieRoll.InvalidValue, (nameof(value), value));

        Type = (int)type;
    }

    public void Deconstruct(out int value, out int type)
    {
        value = Value;
        type = Type;
    }

    public static implicit operator int(DieRoll dieRoll) =>
        dieRoll.Value;

    public override string ToString() =>
        $"{Value}(d{Type})";
}
