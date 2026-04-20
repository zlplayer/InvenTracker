namespace InvenTracker.Application.Dtos;

public class GetItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int MinimumQuantityItem { get; set; }
    public int Quantity { get; set; }
    public bool IsPackaged { get; set; }
    public int? QuantityPerPackage { get; set; }
}