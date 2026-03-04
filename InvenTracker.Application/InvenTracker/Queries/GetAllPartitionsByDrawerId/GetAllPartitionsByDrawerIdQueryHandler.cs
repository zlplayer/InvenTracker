using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllPartitionsByDrawerId;

public class GetAllPartitionsByDrawerIdQueryHandler:IRequestHandler<GetAllPartitionsByDrawerIdQuery, IEnumerable<GetDetailsPartitionsDto>>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IPartitionRepositories _partitionRepositories;

    public GetAllPartitionsByDrawerIdQueryHandler(IMapper mapper, IDrawerRepositories drawerRepositories, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _drawerRepositories = drawerRepositories;
        _partitionRepositories = partitionRepositories;
    }
    public async Task<IEnumerable<GetDetailsPartitionsDto>> Handle(GetAllPartitionsByDrawerIdQuery request, CancellationToken cancellationToken)
    {
        var drawer = await _drawerRepositories.GetDrawer(request.DrawerId);
        if(drawer == null) throw new ArgumentNullException(nameof(drawer));

        var partitions = await _partitionRepositories.GetPartitions(request.DrawerId);
        return _mapper.Map<IEnumerable<GetDetailsPartitionsDto>>(partitions);
    }
}