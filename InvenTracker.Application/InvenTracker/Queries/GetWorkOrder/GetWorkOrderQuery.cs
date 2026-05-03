using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetWorkOrder;

public class GetWorkOrderQuery: IRequest<GetDetailsWorkOrderDto>
{
    public Guid Id { get; init; }
}