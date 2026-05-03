using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;

public class ExecuteWorkOrderCommand : IRequest<string>
{
    public string Code { get; set; }
    public Guid UserId { get; set; }
}