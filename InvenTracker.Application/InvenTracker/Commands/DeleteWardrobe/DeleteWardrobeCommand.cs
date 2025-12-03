using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWardrobe;

public class DeleteWardrobeCommand:IRequest
{
    public Guid WardrobeId { get; set; }
}