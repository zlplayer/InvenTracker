using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreatePartition;

public class CreatePartitionCommandHandler:IRequestHandler<CreatePartitionCommand>
{
    private readonly IPartitionRepositories _partitionRepositories;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IMapper _mapper;

    public CreatePartitionCommandHandler(IMapper mapper,IPartitionRepositories partitionRepositories, IDrawerRepositories drawerRepositories)
    {
        _mapper = mapper;
        _partitionRepositories = partitionRepositories;
        _drawerRepositories = drawerRepositories;
    }
    public async Task Handle(CreatePartitionCommand request, CancellationToken cancellationToken)
    {
        var drawer = await _drawerRepositories.GetDrawer(request.DrawerId);
        if (drawer == null) throw new Exception("Drawer not found");
        
        var partition = _mapper.Map<Partition>(request);
        await _partitionRepositories.CreatePartition(partition);
        
    }
}