using InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;
using InvenTracker.Application.InvenTracker.Commands.DeleteWardrobe;
using InvenTracker.Application.InvenTracker.Commands.UpdateWardrobe;
using InvenTracker.Application.InvenTracker.Queries.GetAllWardrobes;
using InvenTracker.Application.InvenTracker.Queries.GetWardrobe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> DeleteWardrobe(Guid wardrobeId)
    {
        await _mediator.Send(new DeleteWardrobeCommand { WardrobeId = wardrobeId });
        return NoContent();
    }

    [HttpPost("company/{companyId}/department/{departmentId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> CreateWardrobeForBoth(Guid companyId, Guid departmentId, [FromBody] CreateWardrobeCommand command)
    {
        command.CompanyId = companyId;
        command.DepartmentId = departmentId;
        await  _mediator.Send(command);
        return Ok();
    }

    [HttpPost("company/{companyId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> CreateWardrobeForCompany(Guid companyId, [FromBody] CreateWardrobeCommand command)
    {
        command.CompanyId = companyId;
        command.DepartmentId = null;
        await  _mediator.Send(command);
        return Ok();
    }

    [HttpPost("department/{departmentId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> CreateWardrobeForDepartment(Guid departmentId, [FromBody] CreateWardrobeCommand command)
    {
        command.CompanyId = null;
        command.DepartmentId = departmentId;
        await  _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{wardrobeId}")]
    [Authorize(Roles = "Admin,Technik")]
    public async Task<IActionResult> UpdateWardrobe(Guid wardrobeId, [FromBody] UpdateWardrobeCommand command)
    {
        command.WardrobeId= wardrobeId;
        await  _mediator.Send(command);
        return Ok();
    }
}