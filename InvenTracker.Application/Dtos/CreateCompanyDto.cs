namespace InvenTracker.Application.Dtos;

public class CreateCompanyDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public GetAddressCompanyDto? AddressCompany { get; set; }
}