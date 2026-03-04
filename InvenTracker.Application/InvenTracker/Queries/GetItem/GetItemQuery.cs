using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItem;

public class GetItemQuery: IRequest<GetDetailsItemDto>
{
    public Guid ItemId { get; set; }

}