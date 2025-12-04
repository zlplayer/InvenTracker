using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateWardrobe;

public class UpdateWardrobeCommandHandler:IRequestHandler<UpdateWardrobeCommand>
{
    private readonly IMapper _mapper;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public UpdateWardrobeCommandHandler(IMapper mapper, IWardrobeRepositories wardrobeRepositories)
    {
        _mapper = mapper;
        _wardrobeRepositories= wardrobeRepositories;
    }
    public async Task Handle(UpdateWardrobeCommand request, CancellationToken cancellationToken)
    {
        var wardrobe= await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
        if (wardrobe == null) throw new Exception("Wardrobe not found");
        _mapper.Map(request, wardrobe);
        await _wardrobeRepositories.UpdateWardrobe(wardrobe);
    }
}