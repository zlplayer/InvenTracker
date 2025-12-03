using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler:IRequestHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepositories _companyRepositories;

    public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _companyRepositories=companyRepositories;
    }
    
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepositories.GetCompany(request.CompanyId);
        if (company == null) throw new ArgumentNullException(nameof(company));
        await _companyRepositories.DeleteCompany(company);
    }
}