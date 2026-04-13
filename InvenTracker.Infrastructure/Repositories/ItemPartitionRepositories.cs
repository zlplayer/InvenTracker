using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class ItemPartitionRepositories:IItemPartitionRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public ItemPartitionRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ItemPartition?> GetItemPartition(Guid id) => await _dbContext.ItemPartitions.FirstOrDefaultAsync(x=>x.Id == id);
    
    public async Task<ItemPartition?> GetItemPartitionByWardrobeAndItem(Guid wardrobeId, Guid itemId)
    {
        return await _dbContext.ItemPartitions
            .Include(ip => ip.Item)
            .Include(ip => ip.Partition)
            .ThenInclude(p => p.Drawer)
            .ThenInclude(d => d.Wardrobe)
            .FirstOrDefaultAsync(ip =>
                ip.ItemId == itemId &&
                ip.Partition.Drawer.WardrobeId == wardrobeId);
    }

    public async Task<ItemPartition?> GetItemPartitionByWardrobeAndItemFifo(Guid wardrobeId, Guid itemId)
    {
        return await _dbContext.ItemPartitions
            .Include(ip => ip.Item)
            .Include(ip => ip.Partition)
            .ThenInclude(p => p.Drawer)
            .ThenInclude(d => d.Wardrobe)
            .Where(ip =>
                ip.ItemId == itemId &&
                ip.Partition.Drawer.WardrobeId == wardrobeId)
            .OrderBy(ip => ip.AddDate)
            .FirstOrDefaultAsync();
    }
    
    public async Task<List<ItemPartition>> GetAllItemPartitionsByWardrobeAndItemFifo(Guid wardrobeId, Guid itemId) =>
        await _dbContext.ItemPartitions
            .Include(ip => ip.Item)
            .Include(ip => ip.Partition)
            .ThenInclude(p => p.Drawer)
            .ThenInclude(d => d.Wardrobe)
            .Where(ip => ip.ItemId == itemId && ip.Partition.Drawer.WardrobeId == wardrobeId)
            .OrderBy(ip => ip.AddDate)
            .ToListAsync();

    public async Task CreateItemPartition(ItemPartition itemPartition)
    {
        await _dbContext.ItemPartitions.AddAsync(itemPartition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateItemPartition(ItemPartition itemPartition)
    {
        _dbContext.ItemPartitions.Update(itemPartition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteItemPartition(ItemPartition itemPartition)
    {
        _dbContext.ItemPartitions.Remove(itemPartition);
        await _dbContext.SaveChangesAsync();
    }
    
    
}