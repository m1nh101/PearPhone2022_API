using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.ShippingAddresses.Get;

public sealed record GetShippingAddressRequest : IRequest<ActionResponse>;

public sealed record ShippingAddressResponse(
  int Id,
  string Address,
  AddressType Type
);