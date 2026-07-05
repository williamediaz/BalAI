using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BalotoAI.Domain.Repositories;
using BalotoAI.Application.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BalotoAI.Application.Handlers
{
    public class GetDrawsHandler : IRequestHandler<Queries.GetDrawsQuery, IEnumerable<DrawDto>>
    {
        private readonly IDrawRepository _drawRepository;

        public GetDrawsHandler(IDrawRepository drawRepository)
        {
            _drawRepository = drawRepository;
        }

        public async Task<IEnumerable<DrawDto>> Handle(Queries.GetDrawsQuery request, CancellationToken cancellationToken)
        {
            var draws = await _drawRepository.ListAsync();
            return draws.Select(d => new DrawDto(d.Id, d.WinningNumbers, d.DrawDate));
        }
    }
}
