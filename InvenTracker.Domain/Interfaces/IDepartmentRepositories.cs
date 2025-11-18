using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IDepartmentRepositories
{
    Task<IEnumerable<Department>> GetDepartments();
    Task<Department> GetDepartment(Guid id);
    Task CreateCompany(Department department);
    Task UpdateDepartment(Department department);
    Task DeleteDepartment(Department department);
}