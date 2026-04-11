using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByWardrobe;

public class GetItemHistoryByWardrobeQueryHandler : IRequestHandler<GetItemHistoryByWardrobeQuery, IEnumerable<GetItemHistoryDto>>
{
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    private readonly IMapper _mapper;

    public GetItemHistoryByWardrobeQueryHandler(IItemHistoryRepositories itemHistoryRepositories, IMapper mapper)
    {
        _itemHistoryRepositories = itemHistoryRepositories;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetItemHistoryDto>> Handle(GetItemHistoryByWardrobeQuery request, CancellationToken cancellationToken)
    {
        var history = await _itemHistoryRepositories.GetItemHistoryByWardrobe(request.WardrobeId);
        return _mapper.Map<IEnumerable<GetItemHistoryDto>>(history);
    }
}