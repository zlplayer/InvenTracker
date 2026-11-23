using System.Text.Json.Serialization;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.RestockItemPartition;

public class RestockItemPartitionCommand : IRequest<string>
{
    [JsonIgnore] // ustawiane w kontrolerze z URL
    public Guid ItemPartitionId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore] // ustawiane w kontrolerze z tokena JWT
    public Guid UserId { get; set; }
}
