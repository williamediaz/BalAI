using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation;
using MediatR;

namespace BalotoAI.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators != null)
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = new List<FluentValidation.Results.ValidationFailure>();

                foreach (var validator in _validators)
                {
                    var result = await validator.ValidateAsync(context, cancellationToken);
                    if (!result.IsValid)
                        failures.AddRange(result.Errors);
                }

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
