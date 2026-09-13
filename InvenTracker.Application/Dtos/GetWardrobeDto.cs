namespace InvenTracker.Application.Dtos;

public class GetWardrobeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public bool IsOnline { get; set; }
    public GetCompanyDto Company { get; set; }
    public GetAllDepartmentDto Department { get; set; }
    public int ItemsCount { get; set; }
}