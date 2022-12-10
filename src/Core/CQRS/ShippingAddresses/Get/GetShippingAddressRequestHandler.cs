using Core.Entities.Users;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.ShippingAddresses.Get;

public sealed record GetShippingAddressRequestHandler
  : IRequestHandler<GetShippingAddressRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly ICurrentUser _user;

  public GetShippingAddressRequestHandler(UserManager<User> userManager, ICurrentUser user)
  {
    _userManager = userManager;
    _user = user;
  }

  public async Task<ActionResponse> Handle(GetShippingAddressRequest request, CancellationToken cancellationToken)
  {
    var user = await Query.Find(_userManager.Users, new UserSpecification(_user.Id), QueryState.NoTracking);

    var data = user.Addresses
            .Where(e => e.Status == Shared.Enums.Status.Active)
            .Select(e => new ShippingAddressResponse(e.Id, e.Address, e.Type));

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Ok").WithData(data);
  }
}