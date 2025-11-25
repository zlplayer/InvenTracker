namespace InvenTracker.Application.Dtos;

public class CreateCompanyDto
{
    public string Name { get; set; }
    public GetAddressCompanyDto? AddressCompany { get; set; }
}