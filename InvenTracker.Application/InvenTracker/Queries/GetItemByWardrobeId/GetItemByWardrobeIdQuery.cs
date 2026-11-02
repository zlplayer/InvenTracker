using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemByWardrobeId;

public class GetItemByWardrobeIdQuery: IRequest<IEnumerable<GetItemByWardrobeIdDto>>
{
    public Guid WardrobeId { get; set; }
}