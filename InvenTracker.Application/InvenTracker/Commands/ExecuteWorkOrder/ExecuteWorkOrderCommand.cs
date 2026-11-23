using System.Text.Json.Serialization;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.ExecuteWorkOrder;

public class ExecuteWorkOrderCommand : IRequest<string>
{
    public string Code { get; set; }
    [JsonIgnore] // ustawiane w kontrolerze z tokena JWT
    public Guid UserId { get; set; }
}