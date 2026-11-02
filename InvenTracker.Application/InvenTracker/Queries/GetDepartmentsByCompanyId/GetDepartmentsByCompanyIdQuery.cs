using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDepartmentsByCompanyId;

public class GetDepartmentsByCompanyIdQuery: IRequest<IEnumerable<GetDepartmentLookupDto>>
{
    public Guid CompanyId { get; set; }
}