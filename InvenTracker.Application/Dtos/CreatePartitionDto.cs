namespace InvenTracker.Application.Dtos;

public class CreatePartitionDto
{
    public int Z { get; set; }
    public int HeightPartition { get; set; }
    public int WidthPartition { get; set; }
    public int LengthPartition { get; set; }
    public Guid DrawerId { get; set; }
}