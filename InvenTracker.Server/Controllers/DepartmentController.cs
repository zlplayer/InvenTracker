using InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.DeleteDepartaments;
using InvenTracker.Application.InvenTracker.Commands.UpdateDepartaments;
using InvenTracker.Application.InvenTracker.Queries.GetAllDepartaments;
using InvenTracker.Application.InvenTracker.Queries.GetDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController :  ControllerBase
{
    private readonly IMediator _mediator;
    
    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _mediator.Send(new GetAllDepartmentsQuery());
        return Ok(departments);
    }

    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetDepartment(Guid departmentId)
    {
        var department = await _mediator.Send(new GetDepartmentQuery{ DepartmentId= departmentId});
        return Ok(department);
    }

    [HttpPost("{companyId}")]
    public async Task<IActionResult> CreateDepartment(Guid companyId, [FromBody] CreateDepartmentCommand createDepartmentCommand)
    {
        createDepartmentCommand.CompanyId = companyId;
        await _mediator.Send(createDepartmentCommand);
        return Created();
    }

    [HttpPut("{departmentId}")]
    public async Task<IActionResult> UpdateDepartment(Guid departmentId, [FromBody] UpdateDepartmentCommand updateDepartmentCommand)
    {
        updateDepartmentCommand.DepartmentId = departmentId;
        await _mediator.Send(updateDepartmentCommand);
        return Ok();
    }


    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> DeleteDepartment(Guid departmentId)
    {
        await _mediator.Send(new DeleteDepartmentCommand { DepartmentId = departmentId });
        return NoContent();
    }
}