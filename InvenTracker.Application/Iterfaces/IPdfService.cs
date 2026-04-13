using InvenTracker.Application.Dtos;

namespace InvenTracker.Application.Iterfaces;

public interface IPdfService
{
    byte[] GeneratePickupReport(IEnumerable<GetItemHistoryDto> history, string? userName, DateTime from, DateTime to);
    byte[] GenerateWardrobePickupReport(IEnumerable<GetItemHistoryDto> history, string? wardrobeName, DateTime from, DateTime to);
}