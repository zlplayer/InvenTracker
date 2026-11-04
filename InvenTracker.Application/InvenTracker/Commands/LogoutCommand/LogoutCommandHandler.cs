using InvenTracker.Domain.Interfaces;
using MediatR;

namespace InvenTracker.Application.InvenTracker.Commands.LogoutCommand;

public class LogoutCommandHandler:IRequestHandler<LogoutCommand>
{
    private readonly IRefreshTokenRepositories _refreshTokenRepositories;

    public LogoutCommandHandler(IRefreshTokenRepositories refreshTokenRepositories)
    {
        _refreshTokenRepositories = refreshTokenRepositories;
    }
    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepositories.FindByRefreshToken(request.RefreshToken, request.UserId);
        if (refreshToken == null)
            throw new InvalidOperationException("Refresh token not found");

        refreshToken.IsRevoked = true;
        
        await _refreshTokenRepositories.UpdateRefreshToken(refreshToken);
    }
}