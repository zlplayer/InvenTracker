namespace InvenTracker.Application.Dtos;

public class CreateWardrobeDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string SoftwareVersion { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? DepartmentId { get; set; }
}