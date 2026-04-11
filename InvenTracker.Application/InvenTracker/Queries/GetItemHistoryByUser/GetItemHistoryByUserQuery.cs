using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetItemHistoryByUser;

public class GetItemHistoryByUserQuery : IRequest<IEnumerable<GetItemHistoryDto>>
{
    public Guid UserId { get; set; }
}