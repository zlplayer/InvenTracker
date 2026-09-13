namespace InvenTracker.Application.Dtos;

public class GetAllDepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public GetAddressDepartmentDto AddressDepartment { get; set; }
}