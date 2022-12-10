using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.DisableUser;

public sealed class DisableUserRequestHandler
  : IRequestHandler<DisableUserRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ICurrentUser _user;

  public DisableUserRequestHandler(UserManager<User> userManager, ICurrentUser user)
  {
    _userManager = userManager;
    _user = user;
  }

  public async Task<ActionResponse> Handle(DisableUserRequest request, CancellationToken cancellationToken)
  {
    var user = await Query.Find(_userManager.Users, new UserSpecification(_user.Id), QueryState.NoTracking);

    user.SetStatus(false);

    await _userManager.UpdateAsync(user);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Vô hiệu hóa thành công");
  }
}