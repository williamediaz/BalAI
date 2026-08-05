using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using BalAI.Application.Commands.CreateBalance;

namespace BalAI.Web.Pages.Balances
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public decimal Amount { get; set; }

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _mediator.Send(new CreateBalanceCommand(Amount));
            return RedirectToPage("/Balances/Index");
        }
    }
}
