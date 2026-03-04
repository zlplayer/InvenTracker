using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class PartitionRepositories:IPartitionRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public PartitionRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Partition>> GetPartitions(Guid drawerId) => await _dbContext.Partitions.Where(x => x.DrawerId == drawerId).ToListAsync();

    public async Task<Partition?> GetPartitionById(Guid id) => await _dbContext.Partitions.FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task CreatePartition(Partition partition)
    {
        await _dbContext.Partitions.AddAsync(partition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePartition(Partition partition)
    {
        _dbContext.Partitions.Update(partition);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePartition(Partition partition)
    {
        _dbContext.Partitions.Remove(partition);
        await _dbContext.SaveChangesAsync();
    }
}