using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByUser;

public class GetItemHistoryByUserQueryHandler : IRequestHandler<GetItemHistoryByUserQuery, IEnumerable<GetItemHistoryDto>>
{
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    private readonly IMapper _mapper;

    public GetItemHistoryByUserQueryHandler(IItemHistoryRepositories itemHistoryRepositories, IMapper mapper)
    {
        _itemHistoryRepositories = itemHistoryRepositories;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetItemHistoryDto>> Handle(GetItemHistoryByUserQuery request, CancellationToken cancellationToken)
    {
        var history = await _itemHistoryRepositories.GetItemHistoryByUserId(request.UserId);
        return _mapper.Map<IEnumerable<GetItemHistoryDto>>(history);
    }
}