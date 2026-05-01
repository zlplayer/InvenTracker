using InvenTracker.Application.InvenTracker.Commands.CreateItemPartition;
using InvenTracker.Application.InvenTracker.Commands.DeleteItemPartition;
using InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartition;
using InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;
using InvenTracker.Application.InvenTracker.Commands.ReturnItemPartition;
using InvenTracker.Application.InvenTracker.Commands.UpdateItemPartition;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemPartitionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemPartitionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Technik,Dostawca")]
    public async Task<IActionResult> CreateItemPartition([FromBody] CreateItemPartitionCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("{itemPartitionId}")]
    [Authorize(Roles = "Admin,Technik,Dostawca")]
    public async Task<IActionResult> UpdateItemPartition(Guid itemPartitionId, [FromBody] UpdateItemPartitionCommand command)
    {
        command.ItemPartitionId = itemPartitionId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{itemPartitionId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> DeleteItemPartition(Guid itemPartitionId)
    {
        await _mediator.Send(new DeleteItemPartitionCommand { Id = itemPartitionId });
        return NoContent();
    }

    [HttpGet("wardrobe/{wardrobeId}/item/{itemId}")]
    [Authorize(Roles = "Admin,Technik,User")]
    public async Task<IActionResult> RetrieveItemPartition(Guid wardrobeId, Guid itemId, [FromQuery] int quantity, [FromQuery] Guid userId)
    {
        var result = await _mediator.Send(new RetrieveItemPartitionCommand
        {
            WardrobeId = wardrobeId,
            ItemId = itemId,
            Quantity = quantity,
            UserId = userId
        });
        return Ok(result);
    }

    [HttpGet("fifo/wardrobe/{wardrobeId}/item/{itemId}")]
    [Authorize(Roles = "Admin,Technik,User")]
    public async Task<IActionResult> RetrieveItemPartitionFifo(Guid wardrobeId, Guid itemId, [FromQuery] int quantity, [FromQuery] Guid userId)
    {
        var result = await _mediator.Send(new RetrieveItemPartitionFifoCommand
        {
            WardrobeId = wardrobeId,
            ItemId = itemId,
            Quantity = quantity,
            UserId = userId
        });
        return Ok(result);
    }

    [HttpPut("return/item")]
    [Authorize(Roles = "Admin,Technik,User")]
    public async Task<IActionResult> ReturnItemPartition([FromBody] ReturnItemPartitionCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}