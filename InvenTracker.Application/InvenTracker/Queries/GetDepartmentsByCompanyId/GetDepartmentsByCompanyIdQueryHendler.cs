using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDepartmentsByCompanyId;

public class GetDepartmentsByCompanyIdQueryHendler: IRequestHandler<GetDepartmentsByCompanyIdQuery, IEnumerable<GetDepartmentLookupDto>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepositories _departmentRepositories;
    
    public GetDepartmentsByCompanyIdQueryHendler(IMapper mapper, IDepartmentRepositories departmentRepositories)
    {
        _mapper=mapper;
        _departmentRepositories= departmentRepositories;
    }
    
    public async Task<IEnumerable<GetDepartmentLookupDto>> Handle(GetDepartmentsByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var departments= await _departmentRepositories.GetDepartmentsByCompanyId(request.CompanyId);
        
        if(departments==null) throw new ArgumentNullException(nameof(departments));
        
        return _mapper.Map<IEnumerable<GetDepartmentLookupDto>>(departments);
    }
}