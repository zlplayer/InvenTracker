using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class WardrobeRepositories: IWardrobeRepositories
{
    private readonly InvenTrackerDbContext _dbContext;
    
    public WardrobeRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Wardrobe>> GetAllWardrobes() =>await _dbContext.Wardrobes
        .Include(x=>x.Company)
            .ThenInclude(x=>x.Address)
        .Include(x=>x.Department)
            .ThenInclude(x=>x.Address)
        .Include(x=>x.Drawers)
            .ThenInclude(x=>x.Partitions)
                .ThenInclude(x=>x.ItemPartitions)
        .ToListAsync();
    
    public async Task<Wardrobe?> GetWardrobe(Guid wardrobeId) => await _dbContext.Wardrobes
        .Include(x => x.Drawers)
            .ThenInclude(x => x.Partitions)
                .ThenInclude(x => x.ItemPartitions)
                    .ThenInclude(x => x.Item)
        .Include(x=>x.ResponsibleUsers)
            .ThenInclude(x => x.User)
        .FirstOrDefaultAsync(x => x.Id == wardrobeId);

    public async Task CreateWardrobe(Wardrobe wadrobe)
    {
        await _dbContext.Wardrobes.AddAsync(wadrobe);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWardrobe(Wardrobe wadrobe)
    {
        _dbContext.Wardrobes.Update(wadrobe);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteWardrobe(Wardrobe wadrobe)
    {
        _dbContext.Wardrobes.Remove(wadrobe);
        await _dbContext.SaveChangesAsync();
    }
}