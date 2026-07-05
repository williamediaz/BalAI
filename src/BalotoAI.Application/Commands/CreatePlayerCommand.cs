using MediatR;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Commands
{
    public record CreatePlayerCommand(string Name) : IRequest<PlayerDto>;
}
