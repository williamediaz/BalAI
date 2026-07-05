using System;
using BalotoAI.Application;

namespace BalotoAI.Infrastructure.Services
{
    public class SimulationService : ISimulationService
    {
        private readonly Random _rng = new();

        // Simple Monte Carlo stub that returns a probability in [0,1]
        public double RunMonteCarlo(int iterations)
        {
            if (iterations <= 0) return 0.0;
            int wins = 0;
            for (int i = 0; i < iterations; i++)
            {
                // placeholder: random event representing a "win"
                if (_rng.NextDouble() < 0.05) wins++;
            }
            return (double)wins / iterations;
        }
    }
}
