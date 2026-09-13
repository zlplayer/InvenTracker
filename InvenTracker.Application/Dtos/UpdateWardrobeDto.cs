namespace InvenTracker.Application.Dtos;

public class UpdateWardrobeDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string SoftwareVersion { get; set; }
    public bool IsOnline { get; set; }
}