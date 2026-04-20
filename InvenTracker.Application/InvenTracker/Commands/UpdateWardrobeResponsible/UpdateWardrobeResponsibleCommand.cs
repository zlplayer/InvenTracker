using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateWardrobeResponsible;

public class UpdateWardrobeResponsibleCommand : IRequest
{
    public Guid WardrobeResponsibleId { get; set; }
    public Guid UserId { get; set; }
}