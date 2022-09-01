namespace Ares.Domain.Services;

public interface IRandomNumberGenerator
{
    int RandomInt(int minValue, int maxValue);
}
