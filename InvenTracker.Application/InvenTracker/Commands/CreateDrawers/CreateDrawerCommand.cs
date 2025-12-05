using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateDrawers;

public class CreateDrawerCommand: CreateDrawerDto, IRequest
{
    public Guid WardrobeId { get; set; }
}