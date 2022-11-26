using Core.Interfaces;
using MediatR;

namespace Core.CQRS.ShippingAddresses.Delete;

public sealed record RemoveShippingAddressRequest(
  int Id
) : IRequest<ActionResponse>;