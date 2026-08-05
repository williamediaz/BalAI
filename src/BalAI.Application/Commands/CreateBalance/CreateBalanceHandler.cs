using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalAI.Application.Interfaces;
using BalAI.Domain.Entities;

namespace BalAI.Application.Commands.CreateBalance
{
    public class CreateBalanceHandler : IRequestHandler<CreateBalanceCommand, Guid>
    {
        private readonly IBalanceRepository _repository;

        public CreateBalanceHandler(IBalanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Balance { Amount = request.Amount };
            var created = await _repository.AddAsync(entity, cancellationToken);
            return created.Id;
        }
    }
}
