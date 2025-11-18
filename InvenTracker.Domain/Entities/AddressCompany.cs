namespace InvenTracker.Domain.Entities;

public class AddressCompany
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string BuildingNumber  { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    
    public Company? Company { get; set; }
    public Guid CompanyId { get; set; }
}