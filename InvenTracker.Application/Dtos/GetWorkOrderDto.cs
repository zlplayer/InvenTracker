namespace InvenTracker.Application.Dtos;

public class GetWorkOrderDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string status { get; set; }
    public string WardrobeName { get; set; }
}