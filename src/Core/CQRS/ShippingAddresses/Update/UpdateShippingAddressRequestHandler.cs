using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.ShippingAddresses.Update;

public class UpdateShippingAddressRequestHandler
  : IRequestHandler<UpdateShippingAddressRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ICurrentUser _user;

  public UpdateShippingAddressRequestHandler(UserManager<User> userManager, ICurrentUser user)
  {
    _userManager = userManager;
    _user = user;
  }

  public async Task<ActionResponse> Handle(UpdateShippingAddressRequest request, CancellationToken cancellationToken)
  {
    var user = await Query.Find(_userManager.Users, new UserSpecification(_user.Id), QueryState.Tracking);

    var address = new ShippingAddress(request.Address, request.Type);

    user.UpdateShippingAddress(request.Id, address);

    await _userManager.UpdateAsync(user);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Cập nhật thành công").WithData(request);
  }
}
