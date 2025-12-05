using AutoMapper;
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
        if (drawer == null) throw new KeyNotFoundException($"Drawer with id {request.DrawerId} not found");
        await _drawerRepositories.DeleteDrawer(drawer);
    }
}