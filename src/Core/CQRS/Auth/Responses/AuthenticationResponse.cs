namespace Core.CQRS.Auth.Responses;

public class AuthenticationResponse
{
  public string Token { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Fullname { get; set; } = string.Empty;
}