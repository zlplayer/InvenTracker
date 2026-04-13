using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GenerateWardrobePickupReportPdf;

public class GenerateWardrobePickupReportPdfQuery : IRequest<byte[]>
{
    public Guid WardrobeId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
