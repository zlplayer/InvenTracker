using InvenTracker.Application.InvenTracker.Commands.DeleteWardrobe;
using InvenTracker.Application.InvenTracker.Queries.GetAllWardrobes;
using InvenTracker.Application.InvenTracker.Queries.GetWardrobe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WardrobeController: ControllerBase
{
    private readonly IMediator _mediator;

    public WardrobeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetWardrobes()
    {
        var wardrobe = await _mediator.Send(new GetAllWardrobesQuery());
        return Ok(wardrobe);
    }

    [HttpGet("{wardrobeId}")]
    public async Task<IActionResult> GetWardrobe(Guid wardrobeId)
    {
        var wardrobe = await _mediator.Send(new GetWardrobeQuery { WardrobeId = wardrobeId });
        return Ok(wardrobe);
    }

    [HttpDelete("{wardrobeId}")]
    public async Task<IActionResult> DeleteWardrobe(Guid wardrobeId)
    {
        await _mediator.Send(new DeleteWardrobeCommand { WardrobeId = wardrobeId });
        return NoContent();
    }
}