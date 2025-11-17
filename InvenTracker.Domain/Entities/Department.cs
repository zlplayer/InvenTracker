namespace InvenTracker.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public List<Wardrobe> Wardrobes { get; set; }
    
    public Company Company { get; set; }
    public Guid CompanyId { get; set; }
}