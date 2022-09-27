namespace Core.CQRS.Auth.Responses;

public class UserResponse
{
  public string Id { get; set; } = string.Empty;
  public string Username { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Fullname { get; set; } = string.Empty;
}