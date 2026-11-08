using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.CreateCompany;

public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        RuleFor(c => c.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters");
    }
}