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
            .Include(x => x.User)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.ActionAt)
            .ToListAsync();

    public async Task<IEnumerable<ItemHistory>> GetItemHistoryByWardrobe(Guid wardrobeId) =>
        await _dbContext.ItemHistories
            .Include(x => x.User)
            .Where(x => x.WardrobeId == wardrobeId)
            .OrderByDescending(x => x.ActionAt)
            .ToListAsync();

    public async Task<IEnumerable<ItemHistory>> GetItemHistoryForReport(Guid? userId, DateTime? from, DateTime? to)
    {
        var query = _dbContext.ItemHistories
            .Include(x => x.User)
            .AsQueryable();

        if (userId.HasValue)
            query = query.Where(x => x.UserId == userId.Value);

        if (from.HasValue)
            query = query.Where(x => x.ActionAt >= from.Value);

        if (to.HasValue)
            query = query.Where(x => x.ActionAt < to.Value.Date.AddDays(1));

        return await query.OrderByDescending(x => x.ActionAt).ToListAsync();
    }

    public async Task<IEnumerable<ItemHistory>> GetItemHistoryForWardrobeReport(Guid wardrobeId, DateTime from, DateTime to) =>
        await _dbContext.ItemHistories
            .Include(x => x.User)
            .Where(x => x.WardrobeId == wardrobeId && x.ActionAt >= from && x.ActionAt < to.Date.AddDays(1))
            .OrderByDescending(x => x.ActionAt)
            .ToListAsync();

    public async Task CreateItemHistory(ItemHistory item)
    {
        await _dbContext.ItemHistories.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
}