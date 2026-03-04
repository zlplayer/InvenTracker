using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteItemPartition;

public class DeleteItemPartitionCommandHandler:IRequestHandler<DeleteItemPartitionCommand>
{
    private readonly IItemPartitionRepositories _itemPartitionRepositories;

    public DeleteItemPartitionCommandHandler(IItemPartitionRepositories itemPartitionRepositories)
    {
        _itemPartitionRepositories = itemPartitionRepositories;
    }

    public async Task Handle(DeleteItemPartitionCommand request, CancellationToken cancellationToken)
    {
        var  itemPartition = await _itemPartitionRepositories.GetItemPartition(request.Id);
        if (itemPartition == null) throw new NullReferenceException("ItemPartition not found");
        await _itemPartitionRepositories.DeleteItemPartition(itemPartition);
    }
}