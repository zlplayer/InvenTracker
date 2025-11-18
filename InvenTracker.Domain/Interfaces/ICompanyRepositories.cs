using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface ICompanyRepositories
{
    Task<IEnumerable<Company>> GetCompanies();
    Task<Company?> GetCompany(Guid id);
    Task CreateCompany(Company company);
    Task UpdateCompany(Company company);
    Task DeleteCompany(Company company);

}