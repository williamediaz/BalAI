using System.Collections.Generic;
using MediatR;
using BalAI.Application.DTOs;

namespace BalAI.Application.Queries.GetBalances
{
    public record GetBalancesQuery() : IRequest<IEnumerable<BalanceDto>>;
}
