using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllWorkOrder;

public class GetAllWorkOrderQuery: IRequest<IEnumerable<GetWorkOrderDto>>
{
    
}