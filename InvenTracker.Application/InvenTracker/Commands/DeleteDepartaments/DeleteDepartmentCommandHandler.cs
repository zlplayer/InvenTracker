using AutoMapper;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteDepartaments;

public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IDepartmentRepositories _departmentRepositories;
    
    public DeleteDepartmentCommandHandler(IMapper mapper, IDepartmentRepositories departmentRepositories)
    {
        _departmentRepositories=  departmentRepositories;
    }

    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepositories.GetDepartment(request.DepartmentId);
        if( department == null) throw new ArgumentNullException(nameof(department));
        await _departmentRepositories.DeleteDepartment(department);
    }
}