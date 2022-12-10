﻿using System.Net;
using Core.Entities.Users;
using Core.Helpers.Extensions;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Cart.Checkout;

public sealed class CheckoutWithPaypalRequestHandle
  : IRequestHandler<CheckoutWithPaypalRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly ICurrentUser _currentUser;
  private readonly ICheckout _checkout;
  private readonly UserManager<User> _userManager;

  public CheckoutWithPaypalRequestHandle(IAppDbContext context,
      ICurrentUser currentUser,
      ICheckout checkout,
      UserManager<User> userManager)
  {
    _context = context;
    _currentUser = currentUser;
    _checkout = checkout;
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(CheckoutWithPaypalRequest request, CancellationToken cancellationToken)
  {
    var cart = await _context.Orders.CurrentOrder(_currentUser.Id);

    // var user = Query.Get(_userManager.Users, new UserSpecification(_currentUser.Id));

    // var shippingAddress = user.GetShippingAddress(request.ShippingAddressId);
    
    var response = await _checkout.Process(cart);

    return new ActionResponse(HttpStatusCode.OK, "Ok").WithData(new { checkout_url = response});
  }
}