using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.ShippingAddresses.Delete;

public sealed class RemoveShippingAddressRequestHandler
  : IRequestHandler<RemoveShippingAddressRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ICurrentUser _user;

  public RemoveShippingAddressRequestHandler(UserManager<User> userManager,
    ICurrentUser user)
  {
    _userManager = userManager;
    _user = user;
  }

  public async Task<ActionResponse> Handle(RemoveShippingAddressRequest request, CancellationToken cancellationToken)
  {
    var user = Query.Get(_userManager.Users, new UserSpecification(_user.Id), false);

    user.RemoveAddShippingAddress(request.Id);

    await _userManager.UpdateAsync(user);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Xóa thành công");
  }
}