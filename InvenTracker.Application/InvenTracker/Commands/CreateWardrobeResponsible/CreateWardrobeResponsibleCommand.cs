using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobeResponsible;

public class CreateWardrobeResponsibleCommand : IRequest
{
    public Guid WardrobeId { get; set; }
    public Guid UserId { get; set; }
}