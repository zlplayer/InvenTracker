using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GetPartition;

public class GetPartitionQuery: IRequest<GetDetailsPartitionsDto>
{
    public Guid Id { get; set; }

}