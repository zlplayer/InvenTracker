using System.Security.Claims;
using InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByUser;
using InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByWardrobe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("user/{userId}")]
    [Authorize(Roles = "Admin,Technik,User")]
    public async Task<IActionResult> GetItemHistoryByUser(Guid userId)
    {
        // User może widzieć tylko swoją historię
        if (User.IsInRole("User"))
        {
            var currentUserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            if (currentUserId != userId)
                return Forbid();
        }

        var result = await _mediator.Send(new GetItemHistoryByUserQuery { UserId = userId });
        return Ok(result);
    }

    [HttpGet("wardrobe/{wardrobeId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> GetItemHistoryByWardrobe(Guid wardrobeId)
    {
        var result = await _mediator.Send(new GetItemHistoryByWardrobeQuery { WardrobeId = wardrobeId });
        return Ok(result);
    }
}