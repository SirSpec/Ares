using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record HitPoints
{
    public HitPoints(int maximum, int current, int temporary = 0)
    {
        Maximum = maximum > 0
            ? maximum
            : throw new DomainException(ErrorCodes.HitPoints.InvalidArgument, (nameof(maximum), maximum));

        Current = current >= 0 && current <= maximum
            ? current
            : throw new DomainException(ErrorCodes.HitPoints.InvalidArgument, (nameof(current), current));

        Temporary = temporary >= 0
            ? temporary
            : throw new DomainException(ErrorCodes.HitPoints.InvalidArgument, (nameof(temporary), temporary));
    }

    public int Maximum { get; }
    public int Current { get; }
    public int Temporary { get; }

    public int Total => Current + Temporary;

    public static implicit operator int(HitPoints hitPoints) =>
        hitPoints.Total;
}
