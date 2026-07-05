using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Commands
{
    public record CreateDrawCommand(int[] WinningNumbers) : IRequest<DrawDto>;
}
