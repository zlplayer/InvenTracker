using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteUser;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepositories _userRepositories;

    public DeleteUserCommandHandler(IUserRepositories userRepositories)
    {
        _userRepositories = userRepositories;
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user= await _userRepositories.GetUser(request.UserId);
        if (user == null) throw new NullReferenceException("User not found");
        await _userRepositories.DeleteUser(user);
    }
}