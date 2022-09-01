namespace Ares.Domain.Services;

public class RandomAdapter : IRandomNumberGenerator
{
    private readonly Random random;

    public RandomAdapter() =>
        random = new Random();

    public RandomAdapter(int seed) =>
        random = new Random(seed);

    public int RandomInt(int minValue, int maxValue) =>
        random.Next(minValue, maxValue);
}
