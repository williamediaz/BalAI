namespace BalAI.ML.Services
{
    public interface IMarkovService
    {
        // Build Markov chain and sample next state
        void Build(object sequence);
        object Next(object current);
    }

    public class MarkovService : IMarkovService
    {
        public void Build(object sequence)
        {
            // Placeholder for building Markov chain
        }

        public object Next(object current)
        {
            // Placeholder for sampling next state
            return current;
        }
    }
}
