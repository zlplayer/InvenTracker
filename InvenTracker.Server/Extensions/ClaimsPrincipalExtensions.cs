using System.Security.Claims;
using InvenTracker.Domain.Exceptions;

namespace InvenTracker.Server.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var claim = user.FindFirst(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedException("Brak identyfikatora użytkownika w tokenie");
        return Guid.Parse(claim.Value);
    }
}
