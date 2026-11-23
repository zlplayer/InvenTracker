using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;
using InvenTracker.Application.InvenTracker.Commands.DeleteWorkOrder;
using InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;
using InvenTracker.Application.InvenTracker.Queries.GetAllWorkOrder;
using InvenTracker.Application.InvenTracker.Queries.GetWorkOrder;
using InvenTracker.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WorkOrderController:ControllerBase
{
    private readonly IMediator _mediator;

    public WorkOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult>  CreateWorkOrder(CreateWorkOrderCommand workOrder)
    {
        await _mediator.Send(workOrder);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> GetAllWorkOrders()
    {
        var workOrders = await _mediator.Send(new GetAllWorkOrderQuery());
        return Ok(workOrders);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> GetDetailsWorkOrders(Guid id)
    {
        var workOrder = await _mediator.Send(new GetWorkOrderQuery{Id = id});
        return Ok(workOrder);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> DeleteWorkOrders(Guid id)
    {
        await _mediator.Send(new DeleteWorkOrderCommand { WorkOrderId = id });
        return NoContent();
    }
    [HttpPost("execute")]       
    [Authorize(Roles = "Admin,Technik,User")]
    public async Task<IActionResult> ExecuteWorkOrder(ExecuteWorkOrderCommand command)
    {                                                                                                                                                                                                                                                                                                                
        command.UserId = User.GetUserId();
        var result = await _mediator.Send(command);                                                                                                                                                                                                                                                                
        return Ok(result);                                                                                                                                                                                                                                                                                         
    }

}