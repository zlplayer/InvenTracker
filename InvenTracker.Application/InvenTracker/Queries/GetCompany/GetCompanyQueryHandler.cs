using AutoMapper;
using InvenTracker.Application.Dtos;
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
        var company = await _companyRepositories.GetCompany(request.CompanyId);
        
        if (company == null) throw new ArgumentNullException(nameof(company)); 
        
        return _mapper.Map<GetDetailsCompanyDto>(company);
    }
}