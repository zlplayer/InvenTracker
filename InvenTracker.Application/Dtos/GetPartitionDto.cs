namespace InvenTracker.Application.Dtos;

public class GetPartitionDto
{
    public Guid Id { get; set; }
    public int Z { get; set; }
    public int HeightPartition { get; set; }
    public int WidthPartition { get; set; }
    public int LengthPartition { get; set; }
}