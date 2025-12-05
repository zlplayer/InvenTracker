using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllGetDrawers;

public class GetAllDrawersQueryHandler:IRequestHandler<GetAllDrawersQuery, IEnumerable<GetDrawerDto>>
{
    private readonly IDrawerRepositories _drawerRepositories;
    private readonly IMapper _mapper;

    public GetAllDrawersQueryHandler(IMapper mapper, IDrawerRepositories drawerRepositories)
    {
        _mapper = mapper;
        _drawerRepositories=  drawerRepositories;
    }
    public async Task<IEnumerable<GetDrawerDto>> Handle(GetAllDrawersQuery request, CancellationToken cancellationToken)
    {
        var drawers = await _drawerRepositories.GetDrawersByWardrobeId(request.WardrobeId);
        return _mapper.Map<IEnumerable<GetDrawerDto>>(drawers);
    }
}