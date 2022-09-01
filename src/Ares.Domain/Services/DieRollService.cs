using Ares.Domain.Constants;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;

namespace Ares.Domain.Services;

public class DieRollService
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;

    public DieRollService(IRandomNumberGenerator randomNumberGenerator) =>
        _randomNumberGenerator = randomNumberGenerator;

    public DieRoll RollDie(int type) =>
        type >= 1
            ? new DieRoll(
                _randomNumberGenerator.RandomInt(1, type),
                (uint)type)
            : throw new DomainException(ErrorCodes.DieRoll.InvalidType, (nameof(type), type));

    public DieRoll[] RollDice(int count, int type) =>
        count >= 1
            ? Enumerable.Repeat(RollDie(type), count).ToArray()
            : throw new DomainException(ErrorCodes.DieRoll.InvalidRollCount, (nameof(count), count));
}
