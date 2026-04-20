using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWardrobeResponsible;

public class DeleteWardrobeResponsibleCommand : IRequest
{
    public Guid WardrobeResponsibleId { get; set; }
}