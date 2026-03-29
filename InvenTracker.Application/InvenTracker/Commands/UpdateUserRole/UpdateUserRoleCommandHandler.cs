using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateUserRole;

public class UpdateUserRoleCommandHandler: IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IUserRepositories _userRepositories;

    public UpdateUserRoleCommandHandler(IUserRepositories userRepositories)
    {
        _userRepositories= userRepositories;
    }
    public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepositories.GetUser(request.UserId);
        if(user == null) throw new Exception("User not found");
        user.RoleId = request.RoleId;
        await _userRepositories.UpdateUser(user);
    }
}