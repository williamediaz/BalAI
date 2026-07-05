using FluentValidation;
using BalotoAI.Application.Commands;

namespace BalotoAI.Application.Validators
{
    public class CreateDrawValidator : AbstractValidator<CreateDrawCommand>
    {
        public CreateDrawValidator()
        {
            RuleFor(x => x.WinningNumbers)
                .NotNull()
                .Must(nums => nums != null && nums.Length > 0)
                .WithMessage("Winning numbers must contain at least one number.");
        }
    }
}
