using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDrawers;

public class CreateDrawerCommandHandler:IRequestHandler<CreateDrawerCommand>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IWardrobeRepositories _wardrobeRepositories;
    private readonly IPartitionRepositories _partitionRepositories;

    public CreateDrawerCommandHandler(IMapper mapper, IDrawerRepositories drawerRepositories, IWardrobeRepositories wardrobeRepositories, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _drawerRepositories= drawerRepositories;
        _wardrobeRepositories= wardrobeRepositories;
        _partitionRepositories= partitionRepositories;
    }
    public async Task Handle(CreateDrawerCommand request, CancellationToken cancellationToken)
    {
       var wardrobe= await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
       if(wardrobe == null) throw new Exception("Wardrobe not found");
       
       var drawer = _mapper.Map<Drawer>(request);
       await _drawerRepositories.CreateDrawer(drawer);

       for (int i = 1; i <= request.TotalPartitions; i++)
       {
           var partitions = new CreatePartitionDto
           {
               Z = i,
               HeightPartition = request.HeightPartition ?? request.HeightDrawer,
               WidthPartition = request.WidthPartition ?? request.WidthDrawer,
               LengthPartition = request.LengthPartition ?? request.LengthDrawer,
               DrawerId =  drawer.Id
           };
           var partition = _mapper.Map<Partition>(partitions);
           await _partitionRepositories.CreatePartition(partition);
       }
    }
}