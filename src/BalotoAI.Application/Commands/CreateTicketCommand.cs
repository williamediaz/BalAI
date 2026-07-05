using MediatR;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Commands
{
    public record CreateTicketCommand(Guid PlayerId, int[] Numbers) : IRequest<TicketDto>;
}
