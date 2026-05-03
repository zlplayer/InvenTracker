using InvenTracker.Application.InvenTracker.Commands.RetrieveItemPartitionFifo;
using InvenTracker.Domain.Interfaces;
using MediatR;
using System.Text;

namespace InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;

public class ExecuteWorkOrderCommandHandler : IRequestHandler<ExecuteWorkOrderCommand, string>
{
    private readonly IWorkOrderRepositories _workOrderRepositories;
    private readonly IMediator _mediator;

    public ExecuteWorkOrderCommandHandler(IWorkOrderRepositories workOrderRepositories, IMediator mediator)
    {
        _workOrderRepositories = workOrderRepositories;
        _mediator = mediator;
    }

    public async Task<string> Handle(ExecuteWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = await _workOrderRepositories.GetWorkOrderByCode(request.Code);
        if (workOrder == null)
            throw new KeyNotFoundException($"Zlecenie o kodzie '{request.Code}' nie istnieje");

        if (workOrder.Status == "Done")
            throw new InvalidOperationException($"Zlecenie '{request.Code}' zostało już wykonane");

        var summary = new StringBuilder();

        foreach (var item in workOrder.Items)
        {
            var result = await _mediator.Send(new RetrieveItemPartitionFifoCommand
            {
                WardrobeId = workOrder.WardrobeId,
                ItemId = item.ItemId,
                Quantity = item.Quantity,
                UserId = request.UserId
            }, cancellationToken);

            summary.AppendLine(result);
        }

        workOrder.Status = "Done";
        await _workOrderRepositories.UpdateWorkOrder(workOrder);

        return summary.ToString();
    }
}