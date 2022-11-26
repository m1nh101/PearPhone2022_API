using System.Net;
using Core.Entities.Users;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Login;

public sealed class LoginRequestHandler
  : IRequestHandler<LoginRequest, ActionResponse>
{
	private readonly UserManager<User> _userManager;
	private readonly IJwtHelper _jwt;

  public LoginRequestHandler(UserManager<User> userManager, IJwtHelper jwt)
  {
    _userManager = userManager;
    _jwt = jwt;
  }

  public async Task<ActionResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
  {
		var user = await _userManager.FindByEmailAsync(request.Username)
			?? await _userManager.FindByNameAsync(request.Username)
			?? User.Empty();

    var validUserCrendential = await _userManager.CheckPasswordAsync(user, request.Password);

		if(validUserCrendential && user.Active)
		{
      _jwt.SetUser(user);
      var token = await _jwt.GenerateJwtToken();
      var userData = new SuccessLoginResponse(user.UserName, user.Email, user.GetFullName(), token);
      return new ActionResponse(HttpStatusCode.OK, "Đăng nhập thành công")
        .WithData(userData);
    }

		return new ActionResponse(HttpStatusCode.Unauthorized, "Sai tên tài khoản hoặc mật khẩu");
  }
}