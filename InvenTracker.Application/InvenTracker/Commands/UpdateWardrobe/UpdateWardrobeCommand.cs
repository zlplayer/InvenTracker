using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateWardrobe;

public class UpdateWardrobeCommand: UpdateWardrobeDto, IRequest
{
    public Guid WardrobeId { get; set; }
}