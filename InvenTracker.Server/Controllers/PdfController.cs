using InvenTracker.Application.InvenTracker.Queries.GeneratePickupReportPdf;
using InvenTracker.Application.InvenTracker.Queries.GenerateWardrobePickupReportPdf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTracker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PdfController : ControllerBase
{
    private readonly IMediator _mediator;

    public PdfController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("pickup-report")]
    public async Task<IActionResult> GetPickupReport([FromQuery] Guid userId, [FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var pdf = await _mediator.Send(new GeneratePickupReportPdfQuery { UserId = userId, From = from, To = to });
        return File(pdf, "application/pdf", $"raport_pobran_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
    }

    [HttpGet("wardrobe-report")]
    public async Task<IActionResult> GetWardrobePickupReport([FromQuery] Guid wardrobeId, [FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var pdf = await _mediator.Send(new GenerateWardrobePickupReportPdfQuery { WardrobeId = wardrobeId, From = from, To = to });
        return File(pdf, "application/pdf", $"raport_szafa_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
    }
}