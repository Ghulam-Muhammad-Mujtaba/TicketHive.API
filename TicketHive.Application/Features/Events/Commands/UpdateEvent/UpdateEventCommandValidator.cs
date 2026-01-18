using FluentValidation;

namespace TicketHive.Application.Features.Events.Commands.UpdateEvent
{
    /// <summary>
    /// Defines the business rules for creating an event.
    /// FluentValidation ensures data integrity before it reaches the Database.
    /// </summary>
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("The Event ID is required for updates.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("{PropertyName} must be in the future.");

            RuleFor(p => p.Capacity)
                .InclusiveBetween(10, 10000).WithMessage("{PropertyName} must be between 10 and 10,000.");
        }
    }
}
