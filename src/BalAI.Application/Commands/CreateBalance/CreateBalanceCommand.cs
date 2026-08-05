using System;
using MediatR;

namespace BalAI.Application.Commands.CreateBalance
{
    public record CreateBalanceCommand(decimal Amount) : IRequest<Guid>;
}
