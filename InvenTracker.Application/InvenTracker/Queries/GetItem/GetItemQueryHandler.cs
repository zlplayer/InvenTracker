using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItem;

public class GetItemQueryHandler: IRequestHandler<GetItemQuery, GetDetailsItemDto>
{
    private readonly IMapper _mapper;
    private readonly IItemRepositories _itemRepositories;

    public GetItemQueryHandler(IMapper mapper,IItemRepositories itemRepositories)
    {
        _mapper = mapper;
        _itemRepositories = itemRepositories;
    }
    public async Task<GetDetailsItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item =await _itemRepositories.GetItem(request.ItemId);
        return _mapper.Map<GetDetailsItemDto>(item);
    }
}