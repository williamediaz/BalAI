using MediatR;
using BalotoAI.Application.DTOs;
using System.Collections.Generic;

namespace BalotoAI.Application.Queries
{
    public record GetDrawsQuery() : IRequest<IEnumerable<DrawDto>>;
}
