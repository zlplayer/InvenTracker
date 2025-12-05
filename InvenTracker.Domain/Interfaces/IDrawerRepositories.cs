using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IDrawerRepositories
{
    Task<IEnumerable<Drawer>> GetDrawers();
    Task<Drawer?> GetDrawer(Guid drawerId);
    Task CreateDrawer(Drawer drawer);
    Task UpdateDrawer(Drawer drawer);
    Task DeleteDrawer(Drawer drawer);
    Task<IEnumerable<Drawer>> GetDrawersByWardrobeId(Guid wardrobeId);
}