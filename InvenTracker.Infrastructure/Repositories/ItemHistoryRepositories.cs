using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class ItemHistoryRepositories:IItemHistoryRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public ItemHistoryRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ItemHistory?>> GetItemHistoryByUserId(Guid userId) =>
        await _dbContext.ItemHistories
            .Where(x => x.UserId == userId)
            .OrderByDescending(x=>x.ActionAt)
            .ToListAsync();

    public async Task<IEnumerable<ItemHistory>> GetItemHistoryByWardrobe(Guid wardrobeId) =>
        await _dbContext.ItemHistories
            .Where(x => x.WardrobeId == wardrobeId)
            .OrderByDescending(x => x.ActionAt)
            .ToListAsync();

    public async Task CreateItemHistory(ItemHistory item)
    {
        await _dbContext.ItemHistories.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
}