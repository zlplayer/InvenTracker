namespace InvenTracker.Application.Dtos;

public class GetDetailsWardrobeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string SoftwareVersion { get; set; }
    public IEnumerable<GetDrawerDto>  Drawers { get; set; }= new List<GetDrawerDto>();
}