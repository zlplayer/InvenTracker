using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetDrawer;

public class GetDrawerQueryHandler:IRequestHandler<GetDrawerQuery,GetDetailsDrawerDto>
{
    private readonly IMapper _mapper;
    private readonly IDrawerRepositories _drawerRepositories;

    public GetDrawerQueryHandler(IMapper mapper, IDrawerRepositories drawerRepositories)
    {
        _mapper = mapper;
        _drawerRepositories = drawerRepositories;
    }
    public async Task<GetDetailsDrawerDto> Handle(GetDrawerQuery request, CancellationToken cancellationToken)
    {
        var drawer= await _drawerRepositories.GetDrawer(request.Id);
        if (drawer == null) throw new ArgumentNullException(nameof(drawer)); 
        return _mapper.Map<GetDetailsDrawerDto>(drawer);
    }
}