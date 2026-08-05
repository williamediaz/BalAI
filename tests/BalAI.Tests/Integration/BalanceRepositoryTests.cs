using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BalAI.Infrastructure.Persistence;
using BalAI.Infrastructure.Repositories;
using BalAI.Domain.Entities;

namespace BalAI.Tests.Integration
{
    public class BalanceRepositoryTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly BalAIDbContext _context;
        private readonly BalanceRepository _repository;

        public BalanceRepositoryTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<BalAIDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new BalAIDbContext(options);
            _context.Database.EnsureCreated();

            _repository = new BalanceRepository(_context);
        }

        [Fact]
        public async Task AddAndGetAll_ReturnsInsertedEntity()
        {
            var balance = new Balance { Amount = 123.45m };
            var created = await _repository.AddAsync(balance);

            var all = (await _repository.GetAllAsync()).ToList();

            Assert.Single(all);
            Assert.Equal(created.Id, all[0].Id);
            Assert.Equal(123.45m, all[0].Amount);
        }

        public void Dispose()
        {
            _context?.Dispose();
            _connection?.Dispose();
        }
    }
}
