using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllWardrobes;

public class GetAllWardrobesQuery:IRequest<IEnumerable<GetWardrobeDto>>
{
    
}