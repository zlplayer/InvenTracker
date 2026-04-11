namespace InvenTracker.Domain.Entities;

public class ItemPartition
{
    public Guid Id { get; set; }
    public Item Item { get; set; }
    public Guid ItemId { get; set; }
    public Partition Partition { get; set; }
    public Guid PartitionId { get; set; }
    
    public int QuantityItem { get; set; }
    
    public DateTime AddDate { get; set; } = DateTime.UtcNow;
}