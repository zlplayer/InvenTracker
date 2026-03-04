using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetAllPartitionsByDrawerId;

public class GetAllPartitionsByDrawerIdQuery:IRequest<IEnumerable<GetDetailsPartitionsDto>>
{
    public Guid DrawerId { get; set; }
}