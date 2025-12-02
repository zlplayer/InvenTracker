namespace InvenTracker.Application.Dtos;

public class GetWardrobeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string SoftwareVersion { get; set; }
}