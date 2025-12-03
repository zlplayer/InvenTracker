using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.DeleteWardrobe;

public class DeleteWardrobeCommandHandler: IRequestHandler<DeleteWardrobeCommand>
{
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public DeleteWardrobeCommandHandler(IWardrobeRepositories wardrobeRepositories)
    {
        _wardrobeRepositories=wardrobeRepositories;
    }
    
    public async Task Handle(DeleteWardrobeCommand request, CancellationToken cancellationToken)
    {
        var wardrobe= await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
        if (wardrobe == null) throw new ArgumentNullException(nameof(wardrobe));
        await _wardrobeRepositories.DeleteWardrobe(wardrobe);
    }
}