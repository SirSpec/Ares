using Ares.Statistics;

namespace Ares.GameSystemTest.Stubs
{
    public class StubTypeEnhancement<TStatistic> : IEnhancement<TStatistic> where TStatistic : class, IStatistic
    {
        private readonly int value;

        public StubTypeEnhancement(int value) =>
            this.value = value;

        public int Enhance(int _) =>
            value;
    }
}
