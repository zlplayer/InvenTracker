using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemByWardrobeId;

public class GetItemByWardrobeIdQueryHandler: IRequestHandler<GetItemByWardrobeIdQuery, IEnumerable<GetItemByWardrobeIdDto>>
{
    private readonly IMapper _mapper;
    private readonly IItemPartitionRepositories _IItemPartitionRepositories;

    public GetItemByWardrobeIdQueryHandler(IMapper mapper, IItemPartitionRepositories  itemPartitionRepositories )
    {
        _mapper = mapper;
        _IItemPartitionRepositories=  itemPartitionRepositories;
    }
    public async Task<IEnumerable<GetItemByWardrobeIdDto>> Handle(GetItemByWardrobeIdQuery request, CancellationToken cancellationToken)
    {
        var items = await _IItemPartitionRepositories.GetAllItemsByWardrobe(request.WardrobeId);
        return _mapper.Map<IEnumerable<GetItemByWardrobeIdDto>>(items);
    }
}