using Xunit;
using BalotoAI.Infrastructure.Services;

namespace BalotoAI.Tests.UnitTests
{
    public class SimulationTests
    {
        [Fact]
        public void MonteCarlo_ReturnsProbabilityBetweenZeroAndOne()
        {
            var s = new SimulationService();
            var p = s.RunMonteCarlo(1000);
            Assert.InRange(p, 0.0, 1.0);
        }
    }
}
