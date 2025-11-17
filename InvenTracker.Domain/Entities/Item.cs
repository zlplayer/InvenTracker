namespace InvenTracker.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int Partition { get; set; }
    
    public Drawer Drawer { get; set; }
    public Guid DrawerId { get; set; }
}