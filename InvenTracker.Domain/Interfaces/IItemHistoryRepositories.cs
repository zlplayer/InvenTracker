using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IItemHistoryRepositories
{
    Task<IEnumerable<ItemHistory?>> GetItemHistoryByUserId(Guid userId);
    Task<IEnumerable<ItemHistory>> GetItemHistoryByWardrobe(Guid wardrobeId);
    Task<IEnumerable<ItemHistory>> GetItemHistoryForReport(Guid? userId, DateTime? from, DateTime? to);
    Task<IEnumerable<ItemHistory>> GetItemHistoryForWardrobeReport(Guid wardrobeId, DateTime from, DateTime to);
    Task CreateItemHistory(ItemHistory item);
}