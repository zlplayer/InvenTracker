using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.LoginCommand;

public class LoginCommand: LoginDto, IRequest<AuthResponseDto>
{
    
}