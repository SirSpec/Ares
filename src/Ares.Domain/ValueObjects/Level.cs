using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record Level
{
    public const int Maximum = 20;

    public Level(int value) =>
        Value = value >= 1 && value <= Maximum
            ? value
            : throw new DomainException(ErrorCodes.Level.InvalidValue, (nameof(value), value));

    public Level(Experience experience) =>
        Value = CalculateLevelValue(experience);

    public int Value { get; }
    public bool IsMaximum =>
        Value == Maximum;

    public int Tier => Value switch
    {
        >= 1 and <= 4 => 1,
        >= 5 and <= 10 => 2,
        >= 11 and <= 16 => 3,
        >= 17 and <= 20 => 4,
        _ => throw new DomainException(ErrorCodes.Level.InvalidValue, (nameof(Value), Value))
    };

    public static implicit operator int(Level level) =>
        level.Value;

    public void Deconstruct(out int value, out int tier)
    {
        value = Value;
        tier = Tier;
    }

    private static int CalculateLevelValue(Experience experience) =>
        experience.Value switch
        {
            >= Experience.Minimum and < 300 => 1,
            >= 300 and < 900 => 2,
            >= 900 and < 2700 => 3,
            >= 2700 and < 6500 => 4,
            >= 6500 and < 14000 => 5,
            >= 14000 and < 23000 => 6,
            >= 23000 and < 34000 => 7,
            >= 34000 and < 48000 => 8,
            >= 48000 and < 64000 => 9,
            >= 64000 and < 85000 => 10,
            >= 85000 and < 100000 => 11,
            >= 100000 and < 120000 => 12,
            >= 120000 and < 140000 => 13,
            >= 140000 and < 165000 => 14,
            >= 165000 and < 195000 => 15,
            >= 195000 and < 225000 => 16,
            >= 225000 and < 265000 => 17,
            >= 265000 and < 305000 => 18,
            >= 305000 and < Experience.Maximum => 19,
            Experience.Maximum => 20,
            _ => throw new DomainException(ErrorCodes.Level.InvalidValue, (nameof(experience.Value), experience.Value))
        };
}
