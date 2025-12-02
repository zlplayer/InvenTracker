using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateDepartaments;

public class UpdateDepartmentCommand: UpdateDepartmentDto, IRequest
{
    public Guid DepartmentId { get; set; }
}