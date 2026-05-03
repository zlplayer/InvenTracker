namespace InvenTracker.Application.Dtos;

public class GetDetailsWorkOrderDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string status { get; set; }
    public string WardrobeName { get; set; }
    
    public List<GetWorkOrderItemDto> WorkOrderItems { get; set; }
}