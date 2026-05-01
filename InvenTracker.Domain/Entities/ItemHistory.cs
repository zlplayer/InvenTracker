namespace InvenTracker.Domain.Entities;

public class ItemHistory
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid WardrobeId { get; set; }
    public string? WardrobeName { get; set; }
    public string DrawerName { get; set; }
    public string PartitionName { get; set; }
    public string ItemName { get; set; }
    
    public int Quantity { get; set; } // ilość jaką uzytkownik wyciągną 
    public string ActionType { get; set; }
    public DateTime ActionAt { get; set; } = DateTime.UtcNow;
    
    public Guid? ItemPartitionId { get; set; }
    public ItemPartition? ItemPartition { get; set; }
}