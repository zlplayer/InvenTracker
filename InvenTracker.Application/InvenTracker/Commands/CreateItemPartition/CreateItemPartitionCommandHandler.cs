using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateItemPartition;

public class CreateItemPartitionCommandHandler:IRequestHandler<CreateItemPartitionCommand>
{
    private readonly IMapper _mapper;
    private readonly IItemPartitionRepositories _itemPartitionRepositories;
    private readonly IItemRepositories _itemRepositories;
    private readonly IPartitionRepositories _partitionRepositories;

    public CreateItemPartitionCommandHandler(IMapper mapper, IItemPartitionRepositories itemPartitionRepositories, IItemRepositories itemRepositories, IPartitionRepositories partitionRepositories)
    {
        _mapper = mapper;
        _itemPartitionRepositories = itemPartitionRepositories;
        _itemRepositories = itemRepositories;
        _partitionRepositories = partitionRepositories;
    }
    public async Task Handle(CreateItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepositories.GetItem(request.ItemId);
        if (item == null) throw new Exception("Item not found");
        
        var partition = await _partitionRepositories.GetPartitionById(request.PartitionId);
        if (partition == null) throw new Exception("Partition not found");
        
       var itemPartition = _mapper.Map<ItemPartition>(request);
       await _itemPartitionRepositories.CreateItemPartition(itemPartition);
        
    }
}