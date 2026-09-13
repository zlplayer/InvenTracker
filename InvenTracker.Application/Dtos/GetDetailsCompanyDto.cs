namespace InvenTracker.Application.Dtos;

public class GetDetailsCompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public GetAddressCompanyDto? AddressCompany { get; set; }
    public  IEnumerable<GetDepartmentDto?> Departments { get; set; } = new List<GetDepartmentDto>();
    public IEnumerable<GetWardrobeDto> Wardrobe { get; set; } = new List<GetWardrobeDto>();

}