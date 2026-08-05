using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BalAI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR handlers in this assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));

            // Register FluentValidation validators from this assembly
            services.AddValidatorsFromAssembly(typeof(AssemblyMarker).Assembly);

            return services;
        }
    }
}
