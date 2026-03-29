using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDivideDrawer;

public class CreateDivideDrawerCommandHandler: IRequestHandler<CreateDivideDrawerCommand>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IPartitionRepositories _partitionRepositories;

    public CreateDivideDrawerCommandHandler(IMapper mapper, IDrawerRepositories drawerRepositories, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _drawerRepositories = drawerRepositories;
        _partitionRepositories = partitionRepositories;
    }
    public async Task Handle(CreateDivideDrawerCommand request, CancellationToken cancellationToken)
    {
        var parentDrawer = await _drawerRepositories.GetDrawer(request.DrawerId);
        if (parentDrawer == null)
            throw new KeyNotFoundException($"Drawer with id {request.DrawerId} does not exist");

        var available = parentDrawer.AvailablePartitions ?? parentDrawer.TotalPartitions;

        if (available == null || available < request.TotalPartitions)
            throw new InvalidOperationException("Not enough available partitions in parent drawer");

        var partition = await _partitionRepositories.GetPartitionById(request.PartitionId);
        if (partition == null || partition.DrawerId != request.DrawerId)
            throw new KeyNotFoundException($"Partition with id {request.PartitionId} not found in this drawer");

        var subDrawer = _mapper.Map<Drawer>(request);
        subDrawer.WardrobeId = parentDrawer.WardrobeId;
        subDrawer.AvailablePartitions = request.TotalPartitions;
        await _drawerRepositories.CreateDrawer(subDrawer);

        await _partitionRepositories.DeletePartition(partition);

        parentDrawer.AvailablePartitions = available - request.TotalPartitions;
        await _drawerRepositories.UpdateDrawer(parentDrawer);
    }
}