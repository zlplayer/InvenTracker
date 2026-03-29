using System.Security.Claims;
using InvenTracker.Application.InvenTracker.Commands.DeleteUser;
using InvenTracker.Application.InvenTracker.Commands.UpdatePassword;
using InvenTracker.Application.InvenTracker.Commands.UpdateUser;
using InvenTracker.Application.InvenTracker.Commands.UpdateUserRole;
using InvenTracker.Application.InvenTracker.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController: ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var userDto = await _mediator.Send(new GetUserQuery{UserId = id});
        return Ok(userDto);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(userIdClaim.Value);

        var userDto = await _mediator.Send(new GetUserQuery{ UserId = userId });
        return Ok(userDto);
    }
    
    //te funkcje na dole nie są przetestowane
    
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, UpdateUserCommand request)
    {
        request.UserId = userId;
        await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        await _mediator.Send(new DeleteUserCommand{UserId = userId});
        return NoContent();
    }

    [HttpPut("updateRole")]
    public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand request)
    {
       await  _mediator.Send(request);
        return Ok();
    }

    [HttpPut("updatePassword/{userId}")]
    public async Task<IActionResult> UpdatePassword(Guid userId,UpdatePasswordCommand request)
    {
        request.UserId = userId;
        await _mediator.Send(request);
        return Ok();
    }
}