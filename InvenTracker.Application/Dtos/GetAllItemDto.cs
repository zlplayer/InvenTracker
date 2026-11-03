namespace InvenTracker.Application.Dtos;

public class GetAllItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPackaged { get; set; }
    public int? QuantityPerPackage { get; set; }
}