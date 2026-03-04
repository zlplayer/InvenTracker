using InvenTracker.Domain.Entities;

namespace InvenTracker.Application.Dtos;

public class UpdateDrawerDto
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int WidthDrawer { get; set; }
    public int HeightDrawer { get; set; }
    public int LengthDrawer { get; set; }
    public int TotalPartitions { get; set; }
}