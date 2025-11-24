using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class ItemRepositories:IItemRepositories
{
    private readonly InvenTrackerDbContext _dbContext;
    public ItemRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext=dbContext;
    }

    public async Task<IEnumerable<Item>> GetItems() => await _dbContext.Items.ToListAsync();
    
    public async Task<Item?> GetItem(Guid itemId) => await _dbContext.Items.FirstOrDefaultAsync(x=>x.Id == itemId);
    
    public async Task CreateItem(Item item)
    {
        await _dbContext.Items.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateItem(Item item)
    {
        _dbContext.Items.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteItem(Item item)
    {
        _dbContext.Items.Remove(item);
        await _dbContext.SaveChangesAsync();
    }
}