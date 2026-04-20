using System.ComponentModel.DataAnnotations.Schema;

namespace InvenTracker.Domain.Entities;

public class Wardrobe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string SoftwareVersion { get; set; }
    
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }

    
    public List<Drawer> Drawers { get; set; } 
    public List<WardrobeResponsible> ResponsibleUsers { get; set; } = new();

}