using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;

public class UpdateDrawerCommand: UpdateDrawerDto,IRequest
{
    public Guid DrawerId { get; set; }
}