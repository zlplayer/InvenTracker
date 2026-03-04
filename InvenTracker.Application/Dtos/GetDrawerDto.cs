namespace InvenTracker.Application.Dtos;

public class GetDrawerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int WidthDrawer { get; set; }
    public int HeightDrawer { get; set; }
    public int LengthDrawer { get; set; }
    public int TotalPartitions { get; set; }
    public List<GetDetailsPartitionsDto> Partitions { get; set; } = new List<GetDetailsPartitionsDto>();
}