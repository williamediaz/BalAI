using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using BalotoAI.Application.Commands;
using BalotoAI.Application.DTOs;

public class IndexModel : PageModel
{
    private readonly IMediator _mediator;
    public IndexModel(IMediator mediator) => _mediator = mediator;

    public SimulationResultDto? Result { get; set; }

    [BindProperty]
    public int Iterations { get; set; } = 1000;

    public void OnGet() { }

    public async Task OnPostAsync()
    {
        Result = await _mediator.Send(new RunSimulationCommand(Iterations));
    }
}
