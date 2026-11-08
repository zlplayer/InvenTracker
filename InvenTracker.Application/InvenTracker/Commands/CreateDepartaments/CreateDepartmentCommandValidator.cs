using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;

public class CreateDepartmentCommandValidator:AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c=>c.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters");
    }
}