namespace InvenTracker.Domain.Entities;

public class WardrobeResponsible
{
    public Guid Id { get; set; }
    
    public Guid WardrobeId { get; set; }
    public Wardrobe Wardrobe { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}