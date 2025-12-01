using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDepartment;

public class GetDepartmentQuery:IRequest<GetDepartmentDto>
{
    public Guid DepartmentId { get; set; }
}