using MediatR;

namespace BalotoAI.Application.Commands
{
    public record RunSimulationCommand(int Iterations) : IRequest<DTOs.SimulationResultDto>;
}
