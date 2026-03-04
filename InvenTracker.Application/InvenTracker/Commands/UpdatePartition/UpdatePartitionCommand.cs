using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdatePartition;

public class UpdatePartitionCommand: UpdatePartitionDto, IRequest
{
    public Guid PartitionId { get; set; }
}