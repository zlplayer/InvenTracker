using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IItemRepositories
{
    Task<IEnumerable<Item>> GetItems();
    Task<Item?> GetItem(Guid itemId);
    Task CreateItem(Item item);
    Task UpdateItem(Item item);
    Task DeleteItem(Item item);
}