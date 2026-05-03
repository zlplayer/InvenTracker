namespace InvenTracker.Application.Dtos;

public class GetWorkOrderItemDto
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
}