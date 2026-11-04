namespace InvenTracker.Application.Dtos;

public class AuthResponseDto
{
    public string RefreshToken { get; set; }
    public string Token { get; set; }
    public UserDto User { get; set; }
}