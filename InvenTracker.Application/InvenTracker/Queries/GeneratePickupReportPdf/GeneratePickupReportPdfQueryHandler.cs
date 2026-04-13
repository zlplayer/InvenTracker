using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Queries.GeneratePickupReportPdf;

public class GeneratePickupReportPdfQueryHandler : IRequestHandler<GeneratePickupReportPdfQuery, byte[]>
{
    private readonly IItemHistoryRepositories _itemHistoryRepositories;
    private readonly IMapper _mapper;
    private readonly IPdfService _pdfService;

    public GeneratePickupReportPdfQueryHandler(
        IItemHistoryRepositories itemHistoryRepositories,
        IMapper mapper,
        IPdfService pdfService)
    {
        _itemHistoryRepositories = itemHistoryRepositories;
        _mapper = mapper;
        _pdfService = pdfService;
    }

    public async Task<byte[]> Handle(GeneratePickupReportPdfQuery request, CancellationToken cancellationToken)
    {
        var history = await _itemHistoryRepositories.GetItemHistoryForReport(request.UserId, request.From, request.To);
        var dto = _mapper.Map<IEnumerable<GetItemHistoryDto>>(history).ToList();
        var userName = dto.FirstOrDefault()?.UserName;
        return _pdfService.GeneratePickupReport(dto, userName, request.From, request.To);
    }
}