using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateDivideDrawer;
using InvenTracker.Application.InvenTracker.Commands.CreateDrawers;
using InvenTracker.Application.InvenTracker.Commands.DeleteDrawers;
using InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;
using InvenTracker.Application.InvenTracker.Queries.GetAllGetDrawers;
using InvenTracker.Application.InvenTracker.Queries.GetDrawer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrawerController:ControllerBase
{
    private readonly IMediator _mediator;
    public DrawerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Wardrobe/{wardrobeId}")]
    public async Task<IActionResult> GetDrawersByWardrobeId(Guid wardrobeId)
    {
        var drawer = await _mediator.Send(new GetAllDrawersQuery { WardrobeId = wardrobeId });
        return Ok(drawer);
    }

    [HttpGet("{drawerId}")]
    public async Task<IActionResult> GetDrawer(Guid drawerId)
    {
        var drawer = await _mediator.Send(new GetDrawerQuery { Id = drawerId });
        return Ok(drawer);
    }

    [HttpPost("{wardrobeId}")]
    public async Task<IActionResult> CreateDrawer(Guid wardrobeId, [FromBody] CreateDrawerCommand createDrawerCommand)
    {
        createDrawerCommand.WardrobeId = wardrobeId;
        await _mediator.Send(createDrawerCommand);
        return Created();
    }

    [HttpPut("{drawerId}")]
    public async Task<IActionResult> UpdateDrawer(Guid drawerId, [FromBody] UpdateDrawerCommand updateDrawerCommand)
    {
        updateDrawerCommand.DrawerId=drawerId;
        await _mediator.Send(updateDrawerCommand);
        return Ok();
    }

    [HttpDelete("{drawerId}")]
    public async Task<IActionResult> DeleteDrawer(Guid drawerId)
    {
        await _mediator.Send(new DeleteDrawerCommand { DrawerId = drawerId });
        return NoContent();
    }

    [HttpPost("{drawerId}/divide")]
    public async Task<IActionResult> CreateDivideDrawer(Guid drawerId, [FromBody] CreateDivideDrawerCommand createDivideDrawerCommand)
    {
        createDivideDrawerCommand.DrawerId = drawerId;
        await _mediator.Send(createDivideDrawerCommand);
        return Created();
    }
}