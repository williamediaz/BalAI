using System.Threading.Tasks;
using Xunit;
using FluentValidation.TestHelper;
using BalAI.Application.Commands.CreateBalance;

namespace BalAI.Tests.Commands
{
    public class CreateBalanceValidatorTests
    {
        [Fact]
        public void Validator_Fails_For_NonPositiveAmount()
        {
            var validator = new CreateBalanceValidator();
            var result = validator.TestValidate(new CreateBalanceCommand(0));
            result.ShouldHaveValidationErrorFor(x => x.Amount);
        }

        [Fact]
        public void Validator_Passes_For_PositiveAmount()
        {
            var validator = new CreateBalanceValidator();
            var result = validator.TestValidate(new CreateBalanceCommand(100));
            result.ShouldNotHaveValidationErrorFor(x => x.Amount);
        }
    }
}
