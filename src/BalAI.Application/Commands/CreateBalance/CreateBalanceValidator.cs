using FluentValidation;

namespace BalAI.Application.Commands.CreateBalance
{
    public class CreateBalanceValidator : AbstractValidator<CreateBalanceCommand>
    {
        public CreateBalanceValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}
