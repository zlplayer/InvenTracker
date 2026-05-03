using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWorkOrder;

public class DeleteWorkOrderCommandHandler: IRequestHandler<DeleteWorkOrderCommand>
{
    private readonly IWorkOrderRepositories _workOrderRepositories;

    public DeleteWorkOrderCommandHandler(IWorkOrderRepositories workOrderRepositories)
    {
        _workOrderRepositories = workOrderRepositories;
    }
    public async Task Handle(DeleteWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = await _workOrderRepositories.GetWorkOrder(request.WorkOrderId);
        if (workOrder == null) throw new ArgumentNullException(nameof(workOrder));
        await _workOrderRepositories.DeleteWorkOrder(workOrder);
    }
}