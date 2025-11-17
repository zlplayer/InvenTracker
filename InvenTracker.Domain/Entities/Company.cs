namespace InvenTracker.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
    public List<Wardrobe> Wardrobes { get; set; }
    
}