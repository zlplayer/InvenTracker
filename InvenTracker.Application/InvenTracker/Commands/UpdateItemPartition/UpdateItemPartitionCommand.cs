using InvenTracker.Application.Dtos;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.UpdateItemPartition;

public class UpdateItemPartitionCommand: UpdateItemPartitionDto, IRequest
{
    public Guid ItemPartitionId { get; set; }
}