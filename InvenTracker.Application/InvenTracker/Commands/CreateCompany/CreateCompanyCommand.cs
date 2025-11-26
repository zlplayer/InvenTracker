using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateCompany;

public class CreateCompanyCommand: CreateCompanyDto, IRequest
{
}