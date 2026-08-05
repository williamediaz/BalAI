using Microsoft.Extensions.DependencyInjection;

namespace BalAI.ML
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMlServices(this IServiceCollection services)
        {
            services.AddSingleton<Services.INaiveBayesService, Services.NaiveBayesService>();
            services.AddSingleton<Services.IMarkovService, Services.MarkovService>();
            services.AddSingleton<Services.IMonteCarloService, Services.MonteCarloService>();
            services.AddSingleton<Services.IGeneticAlgorithmService, Services.GeneticAlgorithmService>();

            return services;
        }
    }
}
