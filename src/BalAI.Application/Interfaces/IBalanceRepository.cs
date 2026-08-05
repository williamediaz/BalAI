using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BalAI.Domain.Entities;

namespace BalAI.Application.Interfaces
{
    public interface IBalanceRepository
    {
        Task<Balance> AddAsync(Balance entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<Balance>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
