using InvenTracker.Domain.Entities;

namespace InvenTracker.Domain.Interfaces;

public interface IRefreshTokenRepositories
{
    Task<RefreshToken?> FindByRefreshToken(string refreshToken, Guid userId);
    Task CreateRefreshToken(RefreshToken refreshToken);
    Task UpdateRefreshToken(RefreshToken refreshToken);
    Task DeleteRefreshToken(RefreshToken refreshToken);
}