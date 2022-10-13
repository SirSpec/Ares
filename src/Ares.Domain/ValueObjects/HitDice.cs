using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record HitDice
{
    public HitDice(int total, int type)
    {
        Total = total >= 0
            ? total
            : throw new DomainException(ErrorCodes.HitDice.InvalidArgument, (nameof(total), total));

        Type = type >= 1
            ? type
            : throw new DomainException(ErrorCodes.HitDice.InvalidArgument, (nameof(type), type));
    }

    public int Total { get; }
    public int Type { get; }
}
