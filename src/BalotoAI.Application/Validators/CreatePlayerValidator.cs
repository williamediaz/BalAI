using FluentValidation;
using BalotoAI.Application.Commands;

namespace BalotoAI.Application.Validators
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Player name is required");
        }
    }
}
