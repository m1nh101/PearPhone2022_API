using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.Entities.Users;
using Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

public class AuthenticateUserRequestHandler
  : IRequestHandler<AuthenticateUserRequest, CommonResponse<AuthenticationResponse>>
{
  private readonly JwtHelper _jwt;
  private readonly UserManager<User> _userManager;

  public AuthenticateUserRequestHandler(JwtHelper jwt,
    UserManager<User> userManager)
  {
    _jwt = jwt;
    _userManager = userManager;
  }

  public async Task<CommonResponse<AuthenticationResponse>> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
  {
    var user = await _userManager.FindByNameAsync(request.Username)
      ?? await _userManager.FindByEmailAsync(request.Username);

    if(user != null)
    {
      var validUser = await _userManager.CheckPasswordAsync(user, request.Password);

      if (validUser)
      {
        var token = _jwt.SetUser(user).GenerateJwtToken();
        return new CommonResponse<AuthenticationResponse>
        {
          Data = new AuthenticationResponse
          {
            Token = token.Result,
            Fullname = user.GetFullName(),
            Email = user.Email,
            Username = user.UserName
          },
          Message = "Đăng nhập thành công",
          StatusCode = System.Net.HttpStatusCode.OK
        };
      }
    }

    return new CommonResponse<AuthenticationResponse>
    {
      Data = null,
      Message = "Đăng nhập thất bại",
      Errors = new
      {
        Error = "Sai tên đăng nhập/email hoặc mật khẩu"
      },
      StatusCode = System.Net.HttpStatusCode.Unauthorized
    };
  }
}