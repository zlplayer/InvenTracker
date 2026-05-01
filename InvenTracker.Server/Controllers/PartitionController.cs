using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreatePartition;
using InvenTracker.Application.InvenTracker.Commands.DeletePartition;
using InvenTracker.Application.InvenTracker.Commands.UpdatePartition;
using InvenTracker.Application.InvenTracker.Queries.GetAllPartitionsByDrawerId;
using InvenTracker.Application.InvenTracker.Queries.GetPartition;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PartitionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PartitionController(IMediator mediator)
    {
        _mediator=mediator;
    }

    [HttpGet("Drawer/{drawerId}")]
    public async Task<IActionResult> GetPartition(Guid drawerId)
    {
        var  partition = await _mediator.Send(new GetAllPartitionsByDrawerIdQuery { DrawerId = drawerId });
        return Ok(partition);
    }

    [HttpGet("{partitionId}")]
    public async Task<IActionResult> GetPartitions(Guid partitionId)
    {
        var partition = await _mediator.Send(new GetPartitionQuery{Id = partitionId});
        return Ok(partition);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> CreatePartition([FromBody] CreatePartitionCommand createPartitionCommand)
    {
        await _mediator.Send(createPartitionCommand);
        return Ok();
    }

    [HttpPut("{partitionId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> UpdatePartition(Guid partitionId, [FromBody] UpdatePartitionCommand updatePartitionCommand)
    {
        updatePartitionCommand.PartitionId = partitionId;
        await _mediator.Send(updatePartitionCommand);
        return Ok();
    }

    [HttpDelete("{partitionId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> DeletePartition(Guid partitionId)
    {
        await _mediator.Send(new DeletePartitionCommand { Id = partitionId });
        return NoContent();
    }
}