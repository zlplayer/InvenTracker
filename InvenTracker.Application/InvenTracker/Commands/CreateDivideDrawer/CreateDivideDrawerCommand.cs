using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDivideDrawer;

public class CreateDivideDrawerCommand: CreateDivideDrawerDto, IRequest
{
    public Guid DrawerId { get; set; }
}