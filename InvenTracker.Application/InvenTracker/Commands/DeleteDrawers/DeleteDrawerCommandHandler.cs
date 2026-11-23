using AutoMapper;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteDrawers;

public class DeleteDrawerCommandHandler:IRequestHandler<DeleteDrawerCommand>
{
    private readonly IDrawerRepositories _drawerRepositories;

    public DeleteDrawerCommandHandler(IDrawerRepositories drawerRepositories)
    {
        _drawerRepositories = drawerRepositories;
    }
    public async Task Handle(DeleteDrawerCommand request, CancellationToken cancellationToken)
    {
        var drawer = await _drawerRepositories.GetDrawer(request.DrawerId);
        if (drawer == null) throw new NotFoundException($"Drawer with id {request.DrawerId} not found");
        if (drawer.Partitions.Any(p => p.ItemPartitions.Any()))
            throw new ConflictException("Nie można usunąć szuflady - jej przegrody zawierają przedmioty");
        await _drawerRepositories.DeleteDrawer(drawer);
    }
}