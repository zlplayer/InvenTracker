namespace InvenTracker.Application.Dtos;

public class CreateItemPartitionDto
{
    public Guid ItemId { get; set; }
    public Guid PartitionId { get; set; }
    public int? MinimumQuantityItem { get; set; }
    public int QuantityItem { get; set; }
}