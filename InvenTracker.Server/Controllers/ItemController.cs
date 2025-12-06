using InvenTracker.Application.InvenTracker.Commands.CreateItem;
using InvenTracker.Application.InvenTracker.Commands.DeleteItems;
using InvenTracker.Application.InvenTracker.Commands.UpdateItem;
using InvenTracker.Application.InvenTracker.Queries.GetAllItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController:ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var item = await _mediator.Send(new GetAllItemsQuery());
        return Ok(item);
    }

    [HttpPost("{drawerId}")]
    public async Task<IActionResult> CreateItem(Guid drawerId, [FromBody] CreateItemCommand itemCommand)
    {
        itemCommand.DrawerId=drawerId;
        await _mediator.Send(itemCommand);
        return Created();
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] UpdateItemCommand itemCommand)
    {
        itemCommand.ItemId = itemId;
        await  _mediator.Send(itemCommand);
        return Ok();
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> DeleteItem(Guid itemId)
    {
        await _mediator.Send(new DeleteItemCommand { ItemId = itemId });
        return NoContent();
    }
}