using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using BalAI.Application.DTOs;
using BalAI.Application.Queries.GetBalances;

namespace BalAI.Web.Pages.Balances
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IEnumerable<BalanceDto>? Balances { get; set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            Balances = await _mediator.Send(new GetBalancesQuery());
        }
    }
}
