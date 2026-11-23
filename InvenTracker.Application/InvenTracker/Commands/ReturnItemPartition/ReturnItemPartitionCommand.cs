using System.Text.Json.Serialization;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.ReturnItemPartition;

public class ReturnItemPartitionCommand: IRequest<string>
{
    [JsonIgnore] // ustawiane w kontrolerze z tokena JWT
    public Guid UserId { get; set; }
    public Guid WardrobeId { get; set; }
    public Guid ItemPartitionId { get; set; }
    public int Quantity { get; set; }
}