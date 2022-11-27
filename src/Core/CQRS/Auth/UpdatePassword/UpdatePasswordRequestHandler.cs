using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.UpdatePassword;

public sealed class UpdatePasswordRequestHandler
  : IRequestHandler<UpdatePasswordRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ICurrentUser _user;

  public UpdatePasswordRequestHandler(UserManager<User> userManager, ICurrentUser user)
  {
    _userManager = userManager;
    _user = user;
  }

  public async Task<ActionResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
  {
    if(request.NewPassword != request.ConfirmPassword)
      throw new Exception("mật khẩu mới và xác nhận mật khẩu không giống nhau");

    var user = Query.Get(_userManager.Users, new UserSpecification(_user.Id), false);

    var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

    if(result.Succeeded)
      return new ActionResponse(System.Net.HttpStatusCode.OK, "Thay đổi thành công");

    return new ActionResponse(System.Net.HttpStatusCode.BadRequest, "Thay đổi thành công")
      .WithError(result);
  }
}