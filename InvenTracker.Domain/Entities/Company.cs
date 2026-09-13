namespace InvenTracker.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Department> Departments { get; set; }
    public List<Wardrobe> Wardrobes { get; set; }
    
    public AddressCompany? Address { get; set; }
    public Guid AddressId { get; set; }
    
}