using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IWardrobeRepositories
{
    Task<IEnumerable<Wardrobe>> GetAllWardrobes();
    Task<Wardrobe?> GetWardrobe(Guid wardrobeId);
    Task CreateWardrobe(Wardrobe wadrobe);
    Task UpdateWardrobe(Wardrobe wadrobe);
    Task DeleteWardrobe(Wardrobe wadrobe);
}