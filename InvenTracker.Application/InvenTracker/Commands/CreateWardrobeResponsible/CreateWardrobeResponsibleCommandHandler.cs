using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.CreateWardrobeResponsible;

public class CreateWardrobeResponsibleCommandHandler : IRequestHandler<CreateWardrobeResponsibleCommand>
{
    private readonly IWardrobeResponsibleRepositories _wardrobeResponsibleRepositories;
    private readonly IWardrobeRepositories _wardrobeRepositories;
    private readonly IUserRepositories _userRepositories;

    public CreateWardrobeResponsibleCommandHandler(
        IWardrobeResponsibleRepositories wardrobeResponsibleRepositories,
        IWardrobeRepositories wardrobeRepositories,
        IUserRepositories userRepositories)
    {
        _wardrobeResponsibleRepositories = wardrobeResponsibleRepositories;
        _wardrobeRepositories = wardrobeRepositories;
        _userRepositories = userRepositories;
    }

    public async Task Handle(CreateWardrobeResponsibleCommand request, CancellationToken cancellationToken)
    {
        var wardrobe = await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
        if (wardrobe == null) throw new Exception("Wardrobe not found");

        var user = await _userRepositories.GetUser(request.UserId);
        if (user == null) throw new Exception("User not found");

        var responsible = new WardrobeResponsible
        {
            WardrobeId = request.WardrobeId,
            UserId = request.UserId
        };

        await _wardrobeResponsibleRepositories.CreateWardrobeResponsible(responsible);
    }
}