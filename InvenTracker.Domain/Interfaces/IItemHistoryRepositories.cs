using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IItemHistoryRepositories
{
    Task<IEnumerable<ItemHistory?>> GetItemHistoryByUserId(Guid userId);
    Task<IEnumerable<ItemHistory>> GetItemHistoryByWardrobe(Guid wardrobeId);
    Task CreateItemHistory(ItemHistory item);
}