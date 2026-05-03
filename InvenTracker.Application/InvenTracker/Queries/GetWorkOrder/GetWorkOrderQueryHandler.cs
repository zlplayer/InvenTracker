using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetWorkOrder;

public class GetWorkOrderQueryHandler: IRequestHandler<GetWorkOrderQuery, GetDetailsWorkOrderDto>
{
    private readonly IMapper _mapper;
    private readonly IWorkOrderRepositories _workOrderRepositories;

    public GetWorkOrderQueryHandler(IMapper mapper, IWorkOrderRepositories workOrderRepositories)
    {
        _mapper = mapper;
        _workOrderRepositories = workOrderRepositories;
    }
    public async Task<GetDetailsWorkOrderDto> Handle(GetWorkOrderQuery request, CancellationToken cancellationToken)
    {
        var workOrder = await _workOrderRepositories.GetWorkOrder(request.Id);
        return _mapper.Map<GetDetailsWorkOrderDto>(workOrder);
    }
}