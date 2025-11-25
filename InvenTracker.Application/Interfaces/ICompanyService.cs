using InvenTracker.Application.Dtos;

namespace InvenTracker.Application.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<GetCompanyDto>> GetAllCompaniesAsync();
    Task<GetDetailsCompanyDto> GetCompanyAsync(Guid companyId);
    Task CreateCompanyAsync(CreateCompanyDto createCompanyDto);
    Task UpdateCompanyAsync(Guid companyId, CreateCompanyDto createCompanyDto);
    Task DeleteCompanyAsync(Guid companyId);
}