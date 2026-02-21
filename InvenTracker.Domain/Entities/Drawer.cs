namespace InvenTracker.Domain.Entities;

public class Drawer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public int? TotalPartitions { get; set; }      // całkowita liczba przegród
    public int? AvailablePartitions { get; set; }  // dostępne przegrody (po odliczeniu pod-szuflad)
    
    public Guid? ParentDrawerId { get; set; }
    public Drawer? ParentDrawer { get; set; }
    public List<Drawer> SubDrawers { get; set; } = new();
    
    public Guid? WardrobeId { get; set; }
    public Wardrobe? Wardrobe { get; set; }
    public List<Item> Items { get; set; }
}