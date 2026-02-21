namespace InvenTracker.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int Partition { get; set; } // przegroda  TODO: do przerobienia w przyszłości żeby w przedmiocie nie było informacji w której jest przegrodzie tylko w szufladzie trzeba robićić drawer na jeszcze jedną tabele z xyz szuflady
    
    public Drawer Drawer { get; set; }
    public Guid DrawerId { get; set; }
}