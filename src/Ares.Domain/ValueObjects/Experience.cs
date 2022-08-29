using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record Experience
{
    public const int Maximum = 355000;
    public const int Minimum = 0;
    public int Value { get; }

    public Experience(int value) =>
        Value = value >= Minimum && value <= Maximum
            ? value
            : throw new DomainException(ErrorCodes.Experience.InvalidValue, (nameof(value), value));

    public Experience IncreasedBy(Experience experience) =>
        new Experience(Value + experience);

    public static implicit operator int(Experience experience) =>
        experience.Value;
}
