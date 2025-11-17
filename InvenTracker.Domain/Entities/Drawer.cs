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
    
    public Wardrobe Wardrobe { get; set; }
    public Guid WardrobeId { get; set; }
    public List<Item> Items { get; set; }
}