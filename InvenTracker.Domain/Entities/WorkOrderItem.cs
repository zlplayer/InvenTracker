namespace InvenTracker.Domain.Entities;

public class WorkOrderItem
{
    public Guid Id { get; set; }
    
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    
    public Guid WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
    
    public int Quantity { get; set; }
}