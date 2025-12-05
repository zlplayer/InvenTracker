using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllGetDrawers;

public class GetAllDrawersQuery: IRequest<IEnumerable<GetDrawerDto>>
{
    public Guid WardrobeId { get; set; }
}