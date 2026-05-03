namespace InvenTracker.Domain.Entities;

public class WorkOrder
{
    public Guid Id { get; set; }
    public Guid WardrobeId { get; set; }
    public Wardrobe Wardrobe { get; set; } 
    
    public string Code { get; set; }
    public string Status { get; set; }
    
    public ICollection<WorkOrderItem> Items { get; set; }
}