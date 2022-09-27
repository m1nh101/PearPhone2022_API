using Core.CQRS.Auth.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public class AuthenticateUserRequest : IRequest<CommonResponse<AuthenticationResponse>>
{
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}