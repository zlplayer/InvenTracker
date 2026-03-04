using InvenTracker.Application.InvenTracker.Commands.CreateItemPartition;
using InvenTracker.Application.InvenTracker.Commands.DeleteItemPartition;
using InvenTracker.Application.InvenTracker.Commands.UpdateItemPartition;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemPartitionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemPartitionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateItemPartition([FromBody] CreateItemPartitionCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("{itemPartitionId}")]
    public async Task<IActionResult> UpdateItemPartition(Guid itemPartitionId, [FromBody] UpdateItemPartitionCommand command)
    {
        command.ItemPartitionId = itemPartitionId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{itemPartitionId}")]
    public async Task<IActionResult> DeleteItemPartition(Guid itemPartitionId)
    {
        await _mediator.Send(new DeleteItemPartitionCommand { Id = itemPartitionId });
        return NoContent();
    }
}