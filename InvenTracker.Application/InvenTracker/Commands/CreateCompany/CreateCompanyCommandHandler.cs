using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateCompany;

public class CreateCompanyCommandHandler:IRequestHandler<CreateCompanyCommand>
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepositories _companyRepositories;
    
    public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepositories companyRepositories)
    {
        _mapper = mapper;
        _companyRepositories= companyRepositories;
    }
    public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(request);
        
        await _companyRepositories.CreateCompany(company);
        
        if (company?.Address != null)
        {
            company.AddressId = company.Address.Id;
            await _companyRepositories.UpdateCompany(company);
        }
    }
}