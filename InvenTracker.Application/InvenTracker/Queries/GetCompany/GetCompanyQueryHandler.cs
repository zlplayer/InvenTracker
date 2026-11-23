using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Exceptions;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetCompany;

public class GetCompanyQueryHandler:IRequestHandler<GetCompanyQuery, GetDetailsCompanyDto>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepositories _companyRepositories;

    public GetCompanyQueryHandler(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _mapper = mapper;
        _companyRepositories = companyRepositories;
    }
    
    public async Task<GetDetailsCompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepositories.GetCompanyDetails(request.CompanyId);
        
        if (company == null) throw new NotFoundException($"Company with id {request.CompanyId} not found");
        
        return _mapper.Map<GetDetailsCompanyDto>(company);
    }
}