using FluentValidation;
using InvenTracker.Domain.Interfaces;

namespace InvenTracker.Application.InvenTracker.Commands.RegisterCommand;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
    private readonly IUserRepositories _userRepositories;
    public RegisterCommandValidator(IUserRepositories userRepositories)
    {
        _userRepositories = userRepositories;
        
        RuleFor(x=>x.Email)
            .NotEmpty().WithMessage("Email is Empty")
            .EmailAddress().WithMessage("Invalid Email")
            .MustAsync(ValidateEmail).WithMessage("Exist Email");
        
        RuleFor(x=>x.ConfirmPassword)
            .Equal(x=>x.Password).WithMessage("Passwords do not match");
        
        RuleFor(x=>x.Username)
            .NotEmpty().WithMessage("Username is Empty")
            .MustAsync(ValidateUsername).WithMessage("Username is exist");
    }

    private async Task<bool> ValidateEmail(string email, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepositories.GetUserByEmail(email);
        return existingUser == null;
    }
    
    private async Task<bool> ValidateUsername(string username, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepositories.GetUserByUsername(username);
        return existingUser == null;
    }
}