using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllItems;

public class GetAllItemsQuery: IRequest<IEnumerable<GetItemDto>>
{
    
}