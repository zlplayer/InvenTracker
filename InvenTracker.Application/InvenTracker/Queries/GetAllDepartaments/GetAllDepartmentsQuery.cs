using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllDepartaments;

public class GetAllDepartmentsQuery:IRequest<IEnumerable<GetDepartmentDto>>
{
    
}