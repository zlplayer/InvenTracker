using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeletePartition;

public class DeletePartitionCommand:IRequest
{
    public Guid Id { get; set; }
}