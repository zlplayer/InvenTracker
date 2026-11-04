using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class RefreshTokenRepositories:IRefreshTokenRepositories
{
    private readonly InvenTrackerDbContext _dbContext;
    public RefreshTokenRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext= dbContext;
    }
    
    public async Task<RefreshToken?> FindByRefreshToken(string refreshToken, Guid userId) => await  _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken && x.UserId == userId);
    
    public async Task CreateRefreshToken(RefreshToken refreshToken)
    {
        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRefreshToken(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Update(refreshToken);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteRefreshToken(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Remove(refreshToken);
        await _dbContext.SaveChangesAsync();
    }
}