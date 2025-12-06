using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteItems;

public class DeleteItemCommand: IRequest
{
    public Guid ItemId { get; set; }
}