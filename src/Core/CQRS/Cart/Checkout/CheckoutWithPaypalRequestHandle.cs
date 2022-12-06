using System.Net;
using BraintreeHttp;
using Core.Helpers.Extensions;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;

namespace Core.CQRS.Cart.Checkout;

public class CheckoutWithPaypalRequestHandle : IRequestHandler<CheckoutWithPaypalRequest, ActionResponse>
{
  private readonly IAppDbContext _appDbContext;
  private readonly ICurrentUser _currentUser;
  private readonly ICheckout _checkout;
  public double UsdRate = 24938;//store in Database

  public CheckoutWithPaypalRequestHandle(IAppDbContext appDbContext,
      ICurrentUser currentUser,
      ICheckout checkout)
  {
    _appDbContext = appDbContext;
    _currentUser = currentUser;
    _checkout = checkout;
  }

  public async Task<ActionResponse> Handle(CheckoutWithPaypalRequest request, CancellationToken cancellationToken)
  {
    var cart = await _appDbContext.Orders.CurrentOrder(_currentUser.Id);

    var response = await _checkout.Process(cart);

    return new ActionResponse(HttpStatusCode.OK, string.Empty);
  }
}