using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWorkOrder;

public class DeleteWorkOrderCommand: IRequest
{
    public Guid WorkOrderId  { get; set; }
}