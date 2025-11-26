using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllCompanies;

public class GetAllCompaniesQuery:IRequest<IEnumerable<GetCompanyDto>>
{
    
}