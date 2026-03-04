using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateItemPartition;

public class UpdateItemPartitionCommandHandler:IRequestHandler<UpdateItemPartitionCommand>
{
    private readonly IMapper _mapper;
    private readonly IItemPartitionRepositories _itemPartitionRepositories;

    public UpdateItemPartitionCommandHandler(IMapper mapper, IItemPartitionRepositories itemPartitionRepositories)
    {
        _mapper = mapper;
        _itemPartitionRepositories = itemPartitionRepositories;
    }
    public async Task Handle(UpdateItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var itemPartition= await _itemPartitionRepositories.GetItemPartition(request.ItemPartitionId);
        if (itemPartition == null) throw new KeyNotFoundException($"ItemPartition with id {request.ItemPartitionId} not found");
        
        _mapper.Map(request, itemPartition);
        await _itemPartitionRepositories.UpdateItemPartition(itemPartition);
    }
}