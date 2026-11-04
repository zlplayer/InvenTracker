using System.Windows.Input;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RefreshToken;

public class RefreshTokenCommand: IRequest<string>
{
    public string RefreshToken { get; set; }
    public Guid UserId { get; set; }
}