using FluentValidation;

namespace InvenTracker.Application.InvenTracker.Commands.UpdatePassword;

public class UpdatePasswordCommandValidator:AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(x=>x.ConfirmPassword)
            .Equal(x=>x.Password).WithMessage("Passwords do not match");
    }
}