using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BalAI.Application.Interfaces;
using BalAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using BalAI.Infrastructure.Persistence;

namespace BalAI.Infrastructure.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly BalAIDbContext _dbContext;

        public BalanceRepository(BalAIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Balance> AddAsync(Balance entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Balances.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<Balance>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Balances.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
