using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdatePassword;

public class UpdatePasswordCommandHandler:IRequestHandler<UpdatePasswordCommand>
{
    private readonly IUserRepositories _userRepositories;

    public UpdatePasswordCommandHandler(IUserRepositories userRepositories)
    {
        _userRepositories = userRepositories;
    }

    public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepositories.GetUser(request.UserId);
        if (user == null) throw new Exception("User not found");
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        await _userRepositories.UpdateUser(user);
    }
}