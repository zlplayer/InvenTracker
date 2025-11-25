using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.Interfaces;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;

namespace InvenTracker.Application.Services;

public class CompanyService: ICompanyService
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepositories _companyRepositories;
    public CompanyService(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _mapper=mapper;
        _companyRepositories=companyRepositories;
    }

    public async Task<IEnumerable<GetCompanyDto>> GetAllCompaniesAsync()
    {
        var allCompany = await _companyRepositories.GetCompanies();
        return _mapper.Map<IEnumerable<GetCompanyDto>>(allCompany);
    }

    public async Task<GetDetailsCompanyDto> GetCompanyAsync(Guid companyId)
    {
        var company = await _companyRepositories.GetCompany(companyId);
        
        if (company == null) throw new ArgumentNullException(nameof(company)); 
        
        return _mapper.Map<GetDetailsCompanyDto>(company);
    }

    public async Task CreateCompanyAsync(CreateCompanyDto createCompanyDto)
    {
        var company = _mapper.Map<Company>(createCompanyDto);
        
        await _companyRepositories.CreateCompany(company);
        
        if (company?.Address != null)
        {
            company.AddressId = company.Address.Id;
            await _companyRepositories.UpdateCompany(company);
        }
    }

    public async Task UpdateCompanyAsync(Guid companyId, CreateCompanyDto createCompanyDto)
    {
        var company = await _companyRepositories.GetCompany(companyId);
        if (company == null) throw new ArgumentNullException(nameof(company));
        _mapper.Map(createCompanyDto, company);
        await _companyRepositories.UpdateCompany(company);
    }
    
    public async Task DeleteCompanyAsync(Guid companyId)
    {
        var company = await _companyRepositories.GetCompany(companyId);
        if (company == null) throw new ArgumentNullException(nameof(company));
        await _companyRepositories.DeleteCompany(company);
    }
}