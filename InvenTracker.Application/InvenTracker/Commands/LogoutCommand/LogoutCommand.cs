using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.LogoutCommand;

public class LogoutCommand: IRequest
{
    public string RefreshToken { get; set; }
    public Guid UserId { get; set; }
}