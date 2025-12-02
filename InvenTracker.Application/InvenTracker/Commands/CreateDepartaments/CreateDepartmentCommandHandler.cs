using AutoMapper;
using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;

public class CreateDepartmentCommandHandler:IRequestHandler<CreateDepartmentCommand>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepositories _departmentRepositories;
    private readonly ICompanyRepositories _companyRepositories;

    public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepositories departmentRepositories, ICompanyRepositories companyRepositories)
    {
        _mapper = mapper;
        _departmentRepositories = departmentRepositories;
        _companyRepositories = companyRepositories;
    }

    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepositories.GetCompany(request.CompanyId);
        if (company == null)
        {
            throw new KeyNotFoundException($"Company with id {request.CompanyId} not found");
        }

        var department = _mapper.Map<Department>(request);
        await _departmentRepositories.CreateDepartment(department);

        if (department?.Address != null)
        {
            department.AddressId = department.Address.Id;
            await _departmentRepositories.UpdateDepartment(department);
        }
    }
}