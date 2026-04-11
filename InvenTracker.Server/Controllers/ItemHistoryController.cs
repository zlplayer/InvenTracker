using InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByUser;
using InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByWardrobe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetItemHistoryByUser(Guid userId)
    {
        var result = await _mediator.Send(new GetItemHistoryByUserQuery { UserId = userId });
        return Ok(result);
    }

    [HttpGet("wardrobe/{wardrobeId}")]
    public async Task<IActionResult> GetItemHistoryByWardrobe(Guid wardrobeId)
    {
        var result = await _mediator.Send(new GetItemHistoryByWardrobeQuery { WardrobeId = wardrobeId });
        return Ok(result);
    }
}