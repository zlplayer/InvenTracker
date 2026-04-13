namespace InvenTracker.Application.Dtos;

public class GetItemHistoryDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string ItemName { get; set; }
    public string? WardrobeName { get; set; }
    public string DrawerName { get; set; }
    public string PartitionName { get; set; }
    public int Quantity { get; set; }
    public string ActionType { get; set; }
    public DateTime ActionAt { get; set; }
}