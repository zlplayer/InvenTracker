using InvenTracker.Application.Dtos;
using InvenTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies= await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompanyAsync(id);
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto  createCompanyDto)
    {
        await _companyService.CreateCompanyAsync(createCompanyDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CreateCompanyDto createCompanyDto)
    {
        await _companyService.UpdateCompanyAsync(id, createCompanyDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _companyService.DeleteCompanyAsync(id);
        return Ok();
    }
}