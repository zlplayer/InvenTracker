namespace InvenTracker.Application.Dtos;

public class GetDetailsDrawerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public IEnumerable<GetItemDto> Items { get; set; }= new List<GetItemDto>();
}