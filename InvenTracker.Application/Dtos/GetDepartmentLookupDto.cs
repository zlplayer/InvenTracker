namespace InvenTracker.Application.Dtos;

public class GetDepartmentLookupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GetAddressDepartmentDto AddressDepartment { get; set; }

}