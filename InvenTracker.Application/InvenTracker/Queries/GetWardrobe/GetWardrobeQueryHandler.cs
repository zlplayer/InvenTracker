using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetWardrobe;

public class GetWardrobeQueryHandler:IRequestHandler<GetWardrobeQuery, GetDetailsWardrobeDto>
{
    private readonly IMapper _mapper;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public GetWardrobeQueryHandler(IMapper mapper, IWardrobeRepositories wardrobeRepositories)
    {
        _mapper = mapper;
        _wardrobeRepositories = wardrobeRepositories;
    }
    public async Task<GetDetailsWardrobeDto> Handle(GetWardrobeQuery request, CancellationToken cancellationToken)
    {
        var wardrobe = await _wardrobeRepositories.GetWardrobe(request.WardrobeId);
        return _mapper.Map<GetDetailsWardrobeDto>(wardrobe);
    }
}