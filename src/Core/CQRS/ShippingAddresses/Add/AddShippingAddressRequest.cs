using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.ShippingAddresses.Add;

public record AddShippingAddressRequest(
  string Address,
  string City,
  AddressType Type
) : IRequest<ActionResponse>;