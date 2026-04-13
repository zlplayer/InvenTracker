using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GenerateWardrobePickupReportPdf;

public class GenerateWardrobePickupReportPdfQueryHandler : IRequestHandler<GenerateWardrobePickupReportPdfQuery, byte[]>
{
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    private readonly IMapper _mapper;
    private readonly IPdfService _pdfService;

    public GenerateWardrobePickupReportPdfQueryHandler(
        IItemHistoryRepositories itemHistoryRepositories,
        IMapper mapper,
        IPdfService pdfService)
    {
        _itemHistoryRepositories = itemHistoryRepositories;
        _mapper = mapper;
        _pdfService = pdfService;
    }

    public async Task<byte[]> Handle(GenerateWardrobePickupReportPdfQuery request, CancellationToken cancellationToken)
    {
        var history = await _itemHistoryRepositories.GetItemHistoryForWardrobeReport(request.WardrobeId, request.From, request.To);
        var dto = _mapper.Map<IEnumerable<GetItemHistoryDto>>(history).ToList();
        var wardrobeName = dto.FirstOrDefault()?.WardrobeName;
        return _pdfService.GenerateWardrobePickupReport(dto, wardrobeName, request.From, request.To);
    }
}
