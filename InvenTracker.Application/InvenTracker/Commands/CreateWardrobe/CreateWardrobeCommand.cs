using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;

public class CreateWardrobeCommand:CreateWardrobeDto ,IRequest
{
    public Guid? DepartmentId { get; set; }
    public Guid? CompanyId { get; set; }
}