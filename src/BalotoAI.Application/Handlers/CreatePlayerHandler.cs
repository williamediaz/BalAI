using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Domain.Repositories;
using BalotoAI.Domain.Entities;
using BalotoAI.Application.DTOs;

namespace BalotoAI.Application.Handlers
{
    public class CreatePlayerHandler : IRequestHandler<Commands.CreatePlayerCommand, PlayerDto>
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayerDto> Handle(Commands.CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _playerRepository.AddAsync(player);

            return new PlayerDto(player.Id, player.Name);
        }
    }
}
