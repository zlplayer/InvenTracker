namespace InvenTracker.Application.Dtos;

public class CreateRefreshTokenDto
{
    public string Token { get; set; }
    public Guid UserId { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime ExpiresAt { get; set; }

}