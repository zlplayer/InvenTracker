using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.ReturnItemPartition;

public class ReturnItemPartitionCommand: IRequest<string>
{
    public Guid UserId { get; set; }
    public Guid WardrobeId { get; set; }
    public Guid ItemPartitionId { get; set; }
    public int Quantity { get; set; }
}