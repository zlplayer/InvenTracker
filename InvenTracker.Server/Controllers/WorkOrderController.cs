using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;
using InvenTracker.Application.InvenTracker.Commands.DeleteWorkOrder;
using InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;
using InvenTracker.Application.InvenTracker.Queries.GetAllWorkOrder;
using InvenTracker.Application.InvenTracker.Queries.GetWorkOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,Technik")]
public class WorkOrderController:ControllerBase
{
    private readonly IMediator _mediator;

    public WorkOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult>  CreateWorkOrder(CreateWorkOrderCommand workOrder)
    {
        await _mediator.Send(workOrder);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkOrders()
    {
        var workOrders = await _mediator.Send(new GetAllWorkOrderQuery());
        return Ok(workOrders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetailsWorkOrders(Guid id)
    {
        var workOrder = await _mediator.Send(new GetWorkOrderQuery{Id = id});
        return Ok(workOrder);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkOrders(Guid id)
    {
        await _mediator.Send(new DeleteWorkOrderCommand { WorkOrderId = id });
        return NoContent();
    }
    [HttpPost("execute")]       
    [Authorize(Roles = "User,Admin,Technik")]
    public async Task<IActionResult> ExecuteWorkOrder(ExecuteWorkOrderCommand command)
    {                                                                                                                                                                                                                                                                                                                
        var result = await _mediator.Send(command);                                                                                                                                                                                                                                                                
        return Ok(result);                                                                                                                                                                                                                                                                                         
    }

}