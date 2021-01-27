using Ares.Statistics;

namespace Ares.GameSystemTest.Stubs
{
    public class StubEnhancement : IEnhancement<IStatistic>
    {
        private readonly int value;

        public StubEnhancement(int value) =>
            this.value = value;

        public int Enhance(int _) =>
            value;
    }
}
