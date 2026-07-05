using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Domain.Repositories;
using BalotoAI.Domain.Entities;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Handlers
{
    public class CreateDrawHandler : IRequestHandler<Commands.CreateDrawCommand, DrawDto>
    {
        private readonly IDrawRepository _drawRepository;

        public CreateDrawHandler(IDrawRepository drawRepository)
        {
            _drawRepository = drawRepository;
        }

        public async Task<DrawDto> Handle(Commands.CreateDrawCommand request, CancellationToken cancellationToken)
        {
            var draw = new Draw
            {
                Id = Guid.NewGuid(),
                WinningNumbers = request.WinningNumbers,
                DrawDate = DateTime.UtcNow
            };

            await _drawRepository.AddAsync(draw);

            return new DrawDto(draw.Id, draw.WinningNumbers, draw.DrawDate);
        }
    }
}
