using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteDepartaments;

public class DeleteDepartmentCommand:IRequest
{
    public Guid DepartmentId { get; set; }
}