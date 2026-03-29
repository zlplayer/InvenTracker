using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateUserRole;

public class UpdateUserRoleCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}