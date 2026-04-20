namespace InvenTracker.Application.Dtos;

public class GetDetailsItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public bool IsPackaged { get; set; }
    public int? QuantityPerPackage { get; set; }

    //TODO kiedys to będzie działać żeby była lista przegród w których jest przedmiot
    //public List<GetPartitionDto> Partitions { get; set; }
}