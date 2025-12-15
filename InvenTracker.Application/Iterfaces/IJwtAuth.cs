using InvenTracker.Application.Dtos;

namespace InvenTracker.Application.Iterfaces;

public interface IJwtAuth
{
    string GenerateToken(UserDto user);
}