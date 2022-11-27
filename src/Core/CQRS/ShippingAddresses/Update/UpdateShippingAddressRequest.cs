using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.ShippingAddresses.Update;

public sealed record UpdateShippingAddressRequest(
  int Id,
  string Address,
  AddressType Type
) : IRequest<ActionResponse>;
