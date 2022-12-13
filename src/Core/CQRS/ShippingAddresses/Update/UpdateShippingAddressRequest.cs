using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.ShippingAddresses.Update;

public sealed record UpdateShippingAddressRequest(
  int Id,
  string Address,
  string City,
  AddressType Type
) : IRequest<ActionResponse>;
