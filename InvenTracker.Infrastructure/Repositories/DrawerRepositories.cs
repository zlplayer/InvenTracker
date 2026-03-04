using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class DrawerRepositories:IDrawerRepositories
{
    private readonly  InvenTrackerDbContext _dbContext;
    public DrawerRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Drawer>> GetDrawers() => await _dbContext.Drawers.ToListAsync();
    
    public async Task<IEnumerable<Drawer>> GetDrawersByWardrobeId(Guid  wardrobeId) => await _dbContext.Drawers.Where(x => x.WardrobeId == wardrobeId).Include(x=>x.Partitions.OrderBy(p=>p.Z)).ToListAsync();

    public async Task<Drawer?> GetDrawer(Guid drawerId) =>await _dbContext.Drawers.Include(x=>x.Partitions.OrderBy(p=>p.Z)).ThenInclude(x=>x.ItemPartitions).ThenInclude(x=>x.Item).FirstOrDefaultAsync(x=>x.Id == drawerId);
    
    public async Task CreateDrawer(Drawer drawer)
    {
        await _dbContext.Drawers.AddAsync(drawer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDrawer(Drawer drawer)
    {
        _dbContext.Drawers.Update(drawer);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteDrawer(Drawer drawer)
    {
        _dbContext.Drawers.Remove(drawer);
        await _dbContext.SaveChangesAsync();
    }
}