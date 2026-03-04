namespace InvenTracker.Application.Dtos;

public class UpdateItemPartitionDto
{
    public Guid ItemId { get; set; }
    public Guid PartitionId { get; set; }
    public int QuantityItem { get; set; }
}