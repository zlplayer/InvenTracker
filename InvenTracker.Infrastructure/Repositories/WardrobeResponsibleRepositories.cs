using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class WardrobeResponsibleRepositories : IWardrobeResponsibleRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public WardrobeResponsibleRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WardrobeResponsible>> GetWardrobeResponsiblesByWardrobeId(Guid wardrobeId) => await _dbContext.WardrobesResponsibles.Include(x=>x.User).Where(w => w.WardrobeId == wardrobeId).ToListAsync();
    

    public async Task<WardrobeResponsible?> GetWardrobeResponsible(Guid id) =>
        await _dbContext.WardrobesResponsibles.FirstOrDefaultAsync(x => x.Id == id);

    public async Task CreateWardrobeResponsible(WardrobeResponsible responsible)
    {
        await _dbContext.WardrobesResponsibles.AddAsync(responsible);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWardrobeResponsible(WardrobeResponsible responsible)
    {
        _dbContext.WardrobesResponsibles.Update(responsible);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteWardrobeResponsible(WardrobeResponsible responsible)
    {
        _dbContext.WardrobesResponsibles.Remove(responsible);
        await _dbContext.SaveChangesAsync();
    }
}