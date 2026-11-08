using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.CreateItem;

public class CreateItemCommandValidator:AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters");
        RuleFor(c => c.QuantityPerPackage).GreaterThan(0).When(c => c.QuantityPerPackage.HasValue);
    }
}