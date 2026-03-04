using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteItemPartition;

public class DeleteItemPartitionCommand:IRequest
{
    public Guid Id { get; set; }
}