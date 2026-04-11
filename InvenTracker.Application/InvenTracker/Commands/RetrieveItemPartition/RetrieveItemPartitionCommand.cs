using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartition;

public class RetrieveItemPartitionCommand: IRequest<string>
{
    public Guid WardrobeId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public Guid UserId { get; set; }
}