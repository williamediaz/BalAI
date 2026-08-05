using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BalAI.Application.Interfaces;
using BalAI.Infrastructure.Persistence;
using BalAI.Infrastructure.Repositories;

namespace BalAI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BalAIDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IBalanceRepository, BalanceRepository>();

            return services;
        }
    }
}
