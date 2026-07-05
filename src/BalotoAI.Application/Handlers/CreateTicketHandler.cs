using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Domain.Repositories;
using BalotoAI.Domain.Entities;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Handlers
{
    public class CreateTicketHandler : IRequestHandler<Commands.CreateTicketCommand, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketDto> Handle(Commands.CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Numbers = request.Numbers,
                CreatedAt = DateTime.UtcNow
            };

            await _ticketRepository.AddAsync(ticket);

            return new TicketDto(ticket.Id, request.PlayerId, ticket.Numbers, ticket.CreatedAt);
        }
    }
}
