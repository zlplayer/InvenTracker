using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteUser;

public class DeleteUserCommand: IRequest
{
    public Guid UserId { get; set; }
}