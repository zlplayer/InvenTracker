using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler:IRequestHandler<GetAllCompaniesQuery, IEnumerable<GetCompanyDto>>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepositories _companyRepositories;
    
    public GetAllCompaniesQueryHandler(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _mapper = mapper;
        _companyRepositories = companyRepositories;
    }
    public async Task<IEnumerable<GetCompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var allCompany = await _companyRepositories.GetCompanies();
        return _mapper.Map<IEnumerable<GetCompanyDto>>(allCompany);
    }
}