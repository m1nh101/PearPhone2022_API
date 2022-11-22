using System.Net;
using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.ShippingAddresses.Add;

public sealed class AddShippingAddressRequestHandler
  : IRequestHandler<AddShippingAddressRequest, ActionResponse>
{
  private readonly ICurrentUser _user;
  private readonly UserManager<User> _userManager;

  public AddShippingAddressRequestHandler(ICurrentUser user,
    UserManager<User> userManager)
  {
    _user = user;
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(AddShippingAddressRequest request, CancellationToken cancellationToken)
  {
    var user = Query.Get(_userManager.Users, new UserSpecification(_user.Id), false);

    var address = new ShippingAddress(request.Address, request.Type);

    _ = user.AddShippingAddress(address);

    await _userManager.UpdateAsync(user);

    return new ActionResponse(HttpStatusCode.OK, "Thêm địa chỉ thành công", address, null);
  }
}
