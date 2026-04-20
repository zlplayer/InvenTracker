using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWardrobeResponsible;

public class DeleteWardrobeResponsibleCommandHandler : IRequestHandler<DeleteWardrobeResponsibleCommand>
{
    private readonly IWardrobeResponsibleRepositories _wardrobeResponsibleRepositories;

    public DeleteWardrobeResponsibleCommandHandler(IWardrobeResponsibleRepositories wardrobeResponsibleRepositories)
    {
        _wardrobeResponsibleRepositories = wardrobeResponsibleRepositories;
    }

    public async Task Handle(DeleteWardrobeResponsibleCommand request, CancellationToken cancellationToken)
    {
        var responsible = await _wardrobeResponsibleRepositories.GetWardrobeResponsible(request.WardrobeResponsibleId);
        if (responsible == null) throw new ArgumentNullException(nameof(responsible));

        await _wardrobeResponsibleRepositories.DeleteWardrobeResponsible(responsible);
    }
}