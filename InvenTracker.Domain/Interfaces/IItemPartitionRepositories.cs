using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IItemPartitionRepositories
{
    Task<ItemPartition?> GetItemPartition(Guid id);
    Task<ItemPartition?> GetItemPartitionByWardrobeAndItem(Guid wardrobeId, Guid itemId);
    Task CreateItemPartition(ItemPartition itemPartition);
    Task UpdateItemPartition(ItemPartition itemPartition);
    Task DeleteItemPartition(ItemPartition itemPartition);
}