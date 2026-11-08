using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;

public class CreateWardrobeCommandValidator:AbstractValidator<CreateWardrobeCommand>
{
    public CreateWardrobeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c=>c.Model).NotEmpty().WithMessage("Model is required");
        RuleFor(c => c.SerialNumber).NotEmpty().WithMessage("Serial number is required");
        RuleFor(c=>c.SoftwareVersion).NotEmpty().WithMessage("Software version is required");
    }
}