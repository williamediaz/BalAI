using FluentValidation;
using BalotoAI.Application.Commands;

namespace BalotoAI.Application.Validators
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketValidator()
        {
            RuleFor(x => x.Numbers).NotNull().Must(n => n.Length > 0).WithMessage("Ticket must have numbers");
            RuleFor(x => x.PlayerId).NotEmpty().WithMessage("PlayerId is required");
        }
    }
}
