using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;

public class UpdateDrawerCommandHandle:IRequestHandler<UpdateDrawerCommand>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IPartitionRepositories _partitionRepositories;

    public UpdateDrawerCommandHandle(IMapper mapper, IDrawerRepositories drawerRepositories, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _drawerRepositories= drawerRepositories;
        _partitionRepositories = partitionRepositories;
    }
    public async Task Handle(UpdateDrawerCommand request, CancellationToken cancellationToken)
    {
        var drawer =await _drawerRepositories.GetDrawer(request.DrawerId);
        if(drawer == null) throw new NotFoundException($"Drawer with id {request.DrawerId} not found");

        var currentPartitions = drawer.Partitions.OrderBy(p => p.Z).ToList();
        var currentCount = currentPartitions.Count;
        var newCount = request.TotalPartitions;

        // przegrody do usunięcia = te z najwyższym Z ponad nową liczbę
        var partitionsToRemove = currentPartitions.Where(p => p.Z > newCount).ToList();
        if (partitionsToRemove.Any(p => p.ItemPartitions.Any()))
            throw new ConflictException("Nie można zmniejszyć liczby przegród - usuwane przegrody zawierają przedmioty");

        var oldAvailable = drawer.AvailablePartitions;
        _mapper.Map(request, drawer);
        if (oldAvailable != null)
            drawer.AvailablePartitions = oldAvailable + (newCount - currentCount);

        await _drawerRepositories.UpdateDrawer(drawer);

        foreach (var partition in partitionsToRemove)
        {
            await _partitionRepositories.DeletePartition(partition);
        }

        for (int z = currentCount + 1; z <= newCount; z++)
        {
            await _partitionRepositories.CreatePartition(new Partition
            {
                Z = z,
                HeightPartition = drawer.HeightDrawer,
                WidthPartition = drawer.WidthDrawer,
                LengthPartition = drawer.LengthDrawer,
                DrawerId = drawer.Id
            });
        }
    }
}
