using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeletePartition;

public class DeletePartitionCommandHandler: IRequestHandler<DeletePartitionCommand>
{
    private readonly IPartitionRepositories _partitionRepositories;

    public DeletePartitionCommandHandler(IPartitionRepositories partitionRepositories)
    {
        _partitionRepositories = partitionRepositories;
    }
    public async Task Handle(DeletePartitionCommand request, CancellationToken cancellationToken)
    {
        var partial = await _partitionRepositories.GetPartitionById(request.Id);
        if (partial == null) throw new Exception($"Partition with id {request.Id} not found");
        await _partitionRepositories.DeletePartition(partial);
    }
}