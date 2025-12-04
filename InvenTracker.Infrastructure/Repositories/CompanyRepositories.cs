using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class CompanyRepositories:  ICompanyRepositories
{
    private readonly InvenTrackerDbContext _dbContext;
    
    public CompanyRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public async Task<IEnumerable<Company>> GetCompanies()=> await _dbContext.Companies
        .Include(x=>x.Address)
        .Include(x=>x.Wardrobes)
        .Include(x=>x.Departments)
        .ToListAsync();
    
    public async Task<Company?> GetCompany(Guid id){
        
        var companyDetails= await _dbContext.Companies
            .Include(x=>x.Departments).ThenInclude(x=>x.Address)
            .Include(x=>x.Address)
            .Include(x=>x.Wardrobes)
            .FirstOrDefaultAsync(x=>x.Id == id);
        
        if(companyDetails is null) throw new KeyNotFoundException($"Company with id {id} not found");
        
        return companyDetails;
    }
    
    public async Task CreateCompany(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCompany(Company company)
    {
        _dbContext.Companies.Update(company);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCompany(Company company)
    {
       _dbContext.Companies.Remove(company);
       await _dbContext.SaveChangesAsync();
    }
}