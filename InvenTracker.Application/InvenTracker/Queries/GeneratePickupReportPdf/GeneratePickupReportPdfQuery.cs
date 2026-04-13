using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GeneratePickupReportPdf;

public class GeneratePickupReportPdfQuery : IRequest<byte[]>
{
    public Guid UserId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}