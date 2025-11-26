using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetCompany;

public class GetCompanyQuery: IRequest<GetDetailsCompanyDto>
{
    public Guid CompanyId { get; set; }
}