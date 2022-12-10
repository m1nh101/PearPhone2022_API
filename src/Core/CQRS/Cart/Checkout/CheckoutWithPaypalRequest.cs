using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Checkout;

public sealed record CheckoutWithPaypalRequest(
  int ShippingAddressId
) : IRequest<ActionResponse>;