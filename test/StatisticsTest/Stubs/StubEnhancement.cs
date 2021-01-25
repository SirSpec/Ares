using Ares.Statistics.Enhancements;

namespace Ares.StatisticsTest.Stubs
{
    public class StubEnhancement : IEnhancement
    {
        private readonly int value;

        public StubEnhancement(int value) =>
            this.value = value;

        public int Enhance(int _) =>
            value;
    }
}
