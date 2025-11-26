using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteCompany;

public class DeleteCompanyCommand: IRequest
{
    public Guid CompanyId { get; set; }
}