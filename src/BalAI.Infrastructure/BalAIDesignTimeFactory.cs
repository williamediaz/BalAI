using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using BalAI.Infrastructure.Persistence;

namespace BalAI.Infrastructure
{
    // Design-time factory for EF Core tools (dotnet ef migrations add ...)
    public class BalAIDesignTimeFactory : IDesignTimeDbContextFactory<BalAIDbContext>
    {
        public BalAIDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var connection = configuration.GetConnectionString("DefaultConnection")
                ?? "Server=localhost,1433;Database=BalAI;User Id=sa;Password=Password123!;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<BalAIDbContext>();
            optionsBuilder.UseSqlServer(connection);

            return new BalAIDbContext(optionsBuilder.Options);
        }
    }
}
