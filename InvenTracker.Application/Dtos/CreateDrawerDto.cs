namespace InvenTracker.Application.Dtos;

public class CreateDrawerDto
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int WidthDrawer { get; set; }
    public int HeightDrawer { get; set; }
    public int LengthDrawer { get; set; }
    public int TotalPartitions { get; set; }
    
    public int? HeightPartition { get; set; }
    public int? WidthPartition { get; set; }
    public int? LengthPartition { get; set; }
}