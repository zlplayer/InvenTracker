namespace InvenTracker.Application.Dtos;

public class CreateWorkOrderItemDto
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
}