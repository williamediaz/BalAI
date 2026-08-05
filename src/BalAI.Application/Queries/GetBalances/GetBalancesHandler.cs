using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalAI.Application.DTOs;
using BalAI.Application.Interfaces;
using System.Linq;

namespace BalAI.Application.Queries.GetBalances
{
    public class GetBalancesHandler : IRequestHandler<GetBalancesQuery, IEnumerable<BalanceDto>>
    {
        private readonly IBalanceRepository _repository;

        public GetBalancesHandler(IBalanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BalanceDto>> Handle(GetBalancesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return entities.Select(e => new BalanceDto { Id = e.Id, Amount = e.Amount, CreatedAt = e.CreatedAt });
        }
    }
}
