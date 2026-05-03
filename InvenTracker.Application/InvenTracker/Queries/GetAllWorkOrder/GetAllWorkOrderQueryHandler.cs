using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllWorkOrder;

public class GetAllWorkOrderQueryHandler:IRequestHandler<GetAllWorkOrderQuery, IEnumerable<GetWorkOrderDto>>
{
    private readonly IWorkOrderRepositories _workOrderRepositories;
    private readonly IMapper _mapper;

    public GetAllWorkOrderQueryHandler(IMapper mapper, IWorkOrderRepositories workOrderRepositories)
    {
        _mapper = mapper;
        _workOrderRepositories = workOrderRepositories;
    }
    public async Task<IEnumerable<GetWorkOrderDto>> Handle(GetAllWorkOrderQuery request, CancellationToken cancellationToken)
    {
        var workOrder = await _workOrderRepositories.GetWorkOrders();
        return _mapper.Map<IEnumerable<GetWorkOrderDto>>(workOrder);
    }
}