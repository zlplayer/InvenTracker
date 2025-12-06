namespace InvenTracker.Application.Dtos;

public class CreateItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int Partition { get; set; }
    public Guid? DrawerId { get; set; }
}