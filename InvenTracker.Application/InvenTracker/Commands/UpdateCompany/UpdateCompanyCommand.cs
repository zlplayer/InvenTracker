using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateCompany;

public class UpdateCompanyCommand: CreateCompanyDto, IRequest
{
    public Guid CompanyId { get; set; }
}