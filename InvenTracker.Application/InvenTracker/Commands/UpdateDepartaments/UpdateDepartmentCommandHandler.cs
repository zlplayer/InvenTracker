using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateDepartaments;

public class UpdateDepartmentCommandHandler:IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepositories _departmentRepositories;
    public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepositories departmentRepositories)
    {
        _mapper = mapper;
        _departmentRepositories= departmentRepositories;
    }
    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepositories.GetDepartment(request.DepartmentId);
        if(department == null) throw new ArgumentNullException(nameof(department));
        _mapper.Map(request, department);
        await _departmentRepositories.UpdateDepartment(department);
    }
}