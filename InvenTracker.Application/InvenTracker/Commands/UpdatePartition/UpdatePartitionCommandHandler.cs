using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdatePartition;

public class UpdatePartitionCommandHandler: IRequestHandler<UpdatePartitionCommand>
{
    private readonly IPartitionRepositories _partitionRepositories;
    private readonly IMapper _mapper;

    public UpdatePartitionCommandHandler(IMapper mapper, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _partitionRepositories=partitionRepositories;
    }
    public async Task Handle(UpdatePartitionCommand request, CancellationToken cancellationToken)
    {
        var partition= await _partitionRepositories.GetPartitionById(request.PartitionId);
        if (partition == null) throw new ApplicationException($"Partition with id {request.PartitionId} not found");
        
        _mapper.Map(request, partition);
        await _partitionRepositories.UpdatePartition(partition);
    }
}