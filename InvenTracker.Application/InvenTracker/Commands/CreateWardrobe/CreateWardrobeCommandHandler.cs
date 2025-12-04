using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;

public class CreateWardrobeCommandHandler:IRequestHandler<CreateWardrobeCommand>
{
    private readonly IMapper _mapper;
    private readonly IWardrobeRepositories _wardrobeRepositories;
    private readonly ICompanyRepositories _companyRepositories;
    private readonly IDepartmentRepositories _departmentRepositories;

    public CreateWardrobeCommandHandler(IMapper mapper, IWardrobeRepositories wardrobeRepositories, ICompanyRepositories companyRepositories, IDepartmentRepositories departmentRepositories)
    {
        _mapper = mapper;
        _wardrobeRepositories = wardrobeRepositories;
        _companyRepositories = companyRepositories;
        _departmentRepositories = departmentRepositories;
    }
    
    public async Task Handle(CreateWardrobeCommand request, CancellationToken cancellationToken)
    {
        if (request.DepartmentId != null)
        {
            var department= await _departmentRepositories.GetDepartment(request.DepartmentId.Value);
            if (department == null) throw new Exception("Department not found");
        }

        if (request.CompanyId != null)
        {
            var company = await _companyRepositories.GetCompany(request.CompanyId.Value);
            if (company == null) throw new Exception("Company not found");
        }
        
        var wardrobe = _mapper.Map<Wardrobe>(request);
        await _wardrobeRepositories.CreateWardrobe(wardrobe);
    }
}