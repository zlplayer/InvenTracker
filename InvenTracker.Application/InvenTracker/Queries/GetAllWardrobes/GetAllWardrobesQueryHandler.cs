using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllWardrobes;

public class GetAllWardrobesQueryHandler: IRequestHandler<GetAllWardrobesQuery, IEnumerable<GetWardrobeDto>>
{
    private readonly IMapper _mapper;
    private readonly IWardrobeRepositories _wardrobeRepositories;

    public GetAllWardrobesQueryHandler(IMapper mapper, IWardrobeRepositories wardrobeRepositories)
    {
        _mapper = mapper;
        _wardrobeRepositories = wardrobeRepositories;
    }
    public async Task<IEnumerable<GetWardrobeDto>> Handle(GetAllWardrobesQuery request, CancellationToken cancellationToken)
    {
        var wardrobe = await _wardrobeRepositories.GetAllWardrobes();
        
        return _mapper.Map<IEnumerable<GetWardrobeDto>>(wardrobe);
    }
}