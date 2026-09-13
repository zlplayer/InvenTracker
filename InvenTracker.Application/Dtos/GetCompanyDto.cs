namespace InvenTracker.Application.Dtos;

public class GetCompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public GetAddressCompanyDto? AddressCompany { get; set; }
    public int WardrobeCount { get; set; }
    public int DepartementCount { get; set; }
}