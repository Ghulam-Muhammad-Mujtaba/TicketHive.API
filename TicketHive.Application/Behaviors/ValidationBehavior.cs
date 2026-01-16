using FluentValidation;
using MediatR;

namespace TicketHive.Application.Behaviors
{
    /// <summary>
    /// A MediatR Pipeline Behavior that acts as a cross-cutting concern for validation.
    /// It automatically intercepts every request and runs any matching validators.
    /// This ensures that the Handler logic only runs if the data is 100% valid.
    /// </summary>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        // Collection of validators for the request type
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        // Handle method to perform validation
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // Execute all validators for the current request type.
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                // Collect any validation failures.
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // If failures exist, halt the pipeline and throw an exception.
                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            // Proceed to the next behavior or handler in the pipeline
            return await next();
        }
    }
}
