using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllDepartaments;

public class GetAllDepartmentsQueryHandler:IRequestHandler<GetAllDepartmentsQuery, IEnumerable<GetDepartmentDto>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepositories _departmentRepositories;
    public GetAllDepartmentsQueryHandler(IMapper mapper, IDepartmentRepositories departmentRepositories)
    {
        _mapper = mapper;
        _departmentRepositories= departmentRepositories;
    }
    public async Task<IEnumerable<GetDepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = _departmentRepositories.GetDepartments();
        return _mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
    }
}