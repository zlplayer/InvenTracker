using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IWardrobeResponsibleRepositories
{
    Task<WardrobeResponsible?> GetWardrobeResponsible(Guid id);
    Task CreateWardrobeResponsible(WardrobeResponsible responsible);
    Task UpdateWardrobeResponsible(WardrobeResponsible responsible);
    Task DeleteWardrobeResponsible(WardrobeResponsible responsible);
}