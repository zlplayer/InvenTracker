using InvenTracker.Domain.Entities;

namespace InvenTracker.Application.Dtos;

public class GetWorkOrderDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string status { get; set; }
    public string WardrobeName { get; set; }
    public List<GetWorkOrderItemDto> WorkOrderItems { get; set; }
}