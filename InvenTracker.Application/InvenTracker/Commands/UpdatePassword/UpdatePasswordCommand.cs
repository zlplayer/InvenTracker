using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdatePassword;

public class UpdatePasswordCommand:UpdatePasswordDto,IRequest
{
    public Guid UserId { get; set; }
}