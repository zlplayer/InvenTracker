using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IDrawerRepositories
{
    Task<IEnumerable<Drawer>> GetWardrobes();
    Task<Drawer?> GetWardrobe(Guid drawerId);
    Task CreateDrawer(Drawer drawer);
    Task UpdateDrawer(Drawer drawer);
    Task DeleteDrawer(Drawer drawer);
}