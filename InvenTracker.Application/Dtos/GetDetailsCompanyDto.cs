namespace InvenTracker.Application.Dtos;

public class GetDetailsCompanyDto
{
    public string Name { get; set; }
    public GetAddressCompanyDto? AddressCompany { get; set; }
    public  IEnumerable<GetDepartmentDto?> Departments { get; set; } = new List<GetDepartmentDto>();
}