using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWorkOrder;

public class CreateWorkOrderCommand: IRequest
{
    public Guid WardrobeId { get; set; }
    public List<CreateWorkOrderItemDto> WorkOrderItems { get; set; }
}