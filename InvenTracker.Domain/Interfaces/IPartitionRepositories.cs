using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IPartitionRepositories
{
    Task<IEnumerable<Partition>> GetPartitions(Guid drawerId);
    Task<Partition?> GetPartitionById(Guid id);
    Task CreatePartition(Partition partition);
    Task UpdatePartition(Partition partition);
    Task DeletePartition(Partition partition);
}