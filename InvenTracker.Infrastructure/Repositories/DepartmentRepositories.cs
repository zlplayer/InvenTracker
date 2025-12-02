using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class DepartmentRepositories : IDepartmentRepositories
{
    private readonly InvenTrackerDbContext _dbContext;
    
    public DepartmentRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Department>> GetDepartments()=> await _dbContext.Departments
        .Include(x=>x.Address)
        .Include(x=>x.Wardrobes)
        .ToListAsync();

    public async Task<Department> GetDepartment(Guid id)
    {
        var departmetDetails = await  _dbContext.Departments
            .Include(x=>x.Address)
            .Include(x=>x.Wardrobes)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(departmetDetails is null) throw new KeyNotFoundException($"Department with id {id} not found");
        
        return departmetDetails;
    }
    
    public async Task CreateDepartment(Department department)
    {
        await _dbContext.Departments.AddAsync(department);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateDepartment(Department department)
    {
        _dbContext.Departments.Update(department);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteDepartment(Department department)
    {
        _dbContext.Departments.Remove(department);
        await _dbContext.SaveChangesAsync();
    }
}