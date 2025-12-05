using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDrawers;

public class CreateDrawerCommandHandler:IRequestHandler<CreateDrawerCommand>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public CreateDrawerCommandHandler(IMapper mapper, IDrawerRepositories drawerRepositories, IWardrobeRepositories wardrobeRepositories)
    {
        _mapper = mapper;
        _drawerRepositories= drawerRepositories;
        _wardrobeRepositories= wardrobeRepositories;
    }
    public async Task Handle(CreateDrawerCommand request, CancellationToken cancellationToken)
    {
       var wardrobe= await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
       if(wardrobe == null) throw new Exception("Wardrobe not found");
       
       var drawer = _mapper.Map<Drawer>(request);
       await _drawerRepositories.CreateDrawer(drawer);
    }
}