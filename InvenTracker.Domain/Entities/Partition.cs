namespace InvenTracker.Domain.Entities;

public class Partition
{
    public Guid Id { get; set; }
    public int Z { get; set; }
    public int WidthPartition { get; set; }
    public int HeightPartition { get; set; }
    public int LengthPartition { get; set; }
    
    public Drawer Drawer { get; set; }
    public Guid DrawerId { get; set; }
    
    public List<ItemPartition> ItemPartitions { get; set; }
}