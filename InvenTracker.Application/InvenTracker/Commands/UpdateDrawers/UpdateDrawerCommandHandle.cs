using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;

public class UpdateDrawerCommandHandle:IRequestHandler<UpdateDrawerCommand>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;

    public UpdateDrawerCommandHandle(IMapper mapper, IDrawerRepositories drawerRepositories)
    {
        _mapper = mapper;
        _drawerRepositories= drawerRepositories;
    }
    public async Task Handle(UpdateDrawerCommand request, CancellationToken cancellationToken)
    {
        var drawer =await _drawerRepositories.GetDrawer(request.DrawerId);
        if(drawer == null) throw new NullReferenceException("Drawer not found");
        _mapper.Map(request, drawer);
        await _drawerRepositories.UpdateDrawer(drawer);
    }
}