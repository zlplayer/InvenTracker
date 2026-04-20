using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateWardrobeResponsible;

public class UpdateWardrobeResponsibleCommandHandler : IRequestHandler<UpdateWardrobeResponsibleCommand>
{
    private readonly IWardrobeResponsibleRepositories _wardrobeResponsibleRepositories;
    private readonly IUserRepositories _userRepositories;

    public UpdateWardrobeResponsibleCommandHandler(
        IWardrobeResponsibleRepositories wardrobeResponsibleRepositories,
        IUserRepositories userRepositories)
    {
        _wardrobeResponsibleRepositories = wardrobeResponsibleRepositories;
        _userRepositories = userRepositories;
    }

    public async Task Handle(UpdateWardrobeResponsibleCommand request, CancellationToken cancellationToken)
    {
        var responsible = await _wardrobeResponsibleRepositories.GetWardrobeResponsible(request.WardrobeResponsibleId);
        if (responsible == null) throw new ArgumentNullException(nameof(responsible));

        var user = await _userRepositories.GetUser(request.UserId);
        if (user == null) throw new Exception("User not found");

        responsible.UserId = request.UserId;
        await _wardrobeResponsibleRepositories.UpdateWardrobeResponsible(responsible);
    }
}