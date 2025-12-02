namespace InvenTracker.Application.Dtos;

public class UpdateDepartmentDto
{
    public string Name { get; set; } 
    public string Description { get; set; }
    public GetAddressDepartmentDto AddressDepartment { get; set; }
}