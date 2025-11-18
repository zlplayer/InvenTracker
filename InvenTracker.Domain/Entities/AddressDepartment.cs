namespace InvenTracker.Domain.Entities;

public class AddressDepartment
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string BuildingNumber  { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    
    public Department? Department { get; set; }
    public Guid DepartmentId { get; set; }
}