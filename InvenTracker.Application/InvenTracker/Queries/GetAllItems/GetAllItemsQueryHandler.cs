using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllItems;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<GetItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IItemRepositories _itemRepositories;

    public GetAllItemsQueryHandler(IMapper mapper, IItemRepositories itemRepositories)
    {
        _mapper = mapper;
        _itemRepositories = itemRepositories;
    }
    public async Task<IEnumerable<GetItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepositories.GetItems();
        return _mapper.Map<IEnumerable<GetItemDto>>(items);
    }
}