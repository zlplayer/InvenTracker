using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetWardrobe;

public class GetWardrobeQuery : IRequest<GetDetailsWardrobeDto>
{
    public Guid WardrobeId { get; set; }
}