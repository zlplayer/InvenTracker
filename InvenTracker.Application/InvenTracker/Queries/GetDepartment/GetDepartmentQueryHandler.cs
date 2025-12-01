using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDepartment;

public class GetDepartmentQueryHandler:IRequestHandler<GetDepartmentQuery,GetDepartmentDto>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepositories _departmentRepositories;
    
    public GetDepartmentQueryHandler(IMapper mapper, IDepartmentRepositories departmentRepositories)
    {
        _mapper = mapper;
        _departmentRepositories=  departmentRepositories;
    }
    
    public async Task<GetDepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
       var department= await _departmentRepositories.GetDepartment(request.DepartmentId);
       
       if(department==null) throw new ArgumentNullException(nameof(department)); 
       
       return _mapper.Map<GetDepartmentDto>(department);
    }
}