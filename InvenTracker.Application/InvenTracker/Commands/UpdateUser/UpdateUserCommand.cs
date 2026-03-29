using System.Windows.Input;
using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateUser;

public class UpdateUserCommand: UpdateUserDto, IRequest
{
    public Guid UserId { get; set; }
}