namespace BalAI.ML.Services
{
    public interface IMonteCarloService
    {
        double RunSimulation(int iterations);
    }

    public class MonteCarloService : IMonteCarloService
    {
        public double RunSimulation(int iterations)
        {
            // Placeholder Monte Carlo implementation
            double sum = 0;
            var rnd = new System.Random();
            for (int i = 0; i < iterations; i++)
            {
                sum += rnd.NextDouble();
            }
            return sum / iterations;
        }
    }
}
