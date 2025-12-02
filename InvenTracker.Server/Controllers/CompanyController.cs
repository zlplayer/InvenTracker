using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateCompany;
using InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.DeleteCompany;
using InvenTracker.Application.InvenTracker.Commands.UpdateCompany;
using InvenTracker.Application.InvenTracker.Queries.GetAllCompanies;
using InvenTracker.Application.InvenTracker.Queries.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;
    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _mediator.Send(new GetAllCompaniesQuery());
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _mediator.Send(new GetCompanyQuery{CompanyId = id});
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand  companyCommand)
    {
        await _mediator.Send(companyCommand);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody]  UpdateCompanyCommand companyCommand)
    {
        companyCommand.CompanyId = id;
        await _mediator.Send(companyCommand);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _mediator.Send(new DeleteCompanyCommand{CompanyId = id});
        return NoContent();
    }
}