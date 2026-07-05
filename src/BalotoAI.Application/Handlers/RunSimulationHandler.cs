using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Handlers
{
    public class RunSimulationHandler : IRequestHandler<Commands.RunSimulationCommand, SimulationResultDto>
    {
        private readonly ISimulationService _simulationService;

        public RunSimulationHandler(ISimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        public Task<SimulationResultDto> Handle(Commands.RunSimulationCommand request, CancellationToken cancellationToken)
        {
            var result = _simulationService.RunMonteCarlo(request.Iterations);
            return Task.FromResult(new SimulationResultDto(request.Iterations, result));
        }
    }
}
