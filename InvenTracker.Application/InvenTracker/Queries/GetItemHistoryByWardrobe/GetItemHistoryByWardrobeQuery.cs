using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByWardrobe;

public class GetItemHistoryByWardrobeQuery : IRequest<IEnumerable<GetItemHistoryDto>>
{
    public Guid WardrobeId { get; set; }
}