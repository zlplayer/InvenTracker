using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;

public class CreateDepartmentCommand: CreateDepartmentDto, IRequest
{
    public Guid CompanyId { get; set; }
}