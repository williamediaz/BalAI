using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BalAI.Application.Commands.CreateBalance;
using BalAI.Application.Queries.GetBalances;

namespace BalAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetBalancesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBalanceCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }
    }
}
