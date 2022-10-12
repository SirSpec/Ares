using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record DeathSaves
{
    public DeathSaves(int successes = 0, int failures = 0)
    {
        Successes = IsValueInRange(successes)
            ? successes
            : throw new DomainException(ErrorCodes.DeathSaves.InvalidArgument, (nameof(successes), successes));

        Failures = IsValueInRange(failures)
            ? failures
            : throw new DomainException(ErrorCodes.DeathSaves.InvalidArgument, (nameof(failures), failures));
    }

    public int Successes { get; }
    public int Failures { get; }

    public void Deconstruct(out int successes, out int failures)
    {
        successes = Successes;
        failures = Failures;
    }

    private static bool IsValueInRange(int value) =>
        value >= 0 && value <= 3;
}
