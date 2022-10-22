using System.Net;
using Core.Entities.Users;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Register;
public sealed class RegisterRequestHandler
  : IRequestHandler<RegisterRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;

  public RegisterRequestHandler(UserManager<User> userManager)
  {
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
  {
    var user = new User(request.FirstName, request.LastName, request.Username, request.Email);

    var register = await _userManager.CreateAsync(user, request.Password);

    if(register.Succeeded)
    {
      await _userManager.AddToRoleAsync(user, "customer");
      return new(HttpStatusCode.OK, "Đăng ký thành công", default, default);
    }
    else
      return new(HttpStatusCode.BadRequest, "Đăng ký thất bại", default, register.Errors);
  }
}
