using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateCompany;

public class UpdateCompanyCommandHandler:IRequestHandler<UpdateCompanyCommand>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepositories _companyRepositories;

    public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _mapper = mapper;
        _companyRepositories = companyRepositories;
    }
    
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepositories.GetCompany(request.CompanyId);
        if (company == null) throw new ArgumentNullException(nameof(company));
        _mapper.Map(request, company);
        await _companyRepositories.UpdateCompany(company);
    }
}