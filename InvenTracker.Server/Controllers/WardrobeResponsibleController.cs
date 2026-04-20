using InvenTracker.Application.InvenTracker.Commands.CreateWardrobeResponsible;
using InvenTracker.Application.InvenTracker.Commands.DeleteWardrobeResponsible;
using InvenTracker.Application.InvenTracker.Commands.UpdateWardrobeResponsible;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WardrobeResponsibleController : ControllerBase
{
    private readonly IMediator _mediator;

    public WardrobeResponsibleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWardrobeResponsible([FromBody] CreateWardrobeResponsibleCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{wardrobeResponsibleId}")]
    public async Task<IActionResult> UpdateWardrobeResponsible(Guid wardrobeResponsibleId, [FromBody] UpdateWardrobeResponsibleCommand command)
    {
        command.WardrobeResponsibleId = wardrobeResponsibleId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{wardrobeResponsibleId}")]
    public async Task<IActionResult> DeleteWardrobeResponsible(Guid wardrobeResponsibleId)
    {
        await _mediator.Send(new DeleteWardrobeResponsibleCommand { WardrobeResponsibleId = wardrobeResponsibleId });
        return NoContent();
    }
}