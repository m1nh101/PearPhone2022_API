using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.ApplyVoucher;

public sealed record ApplyVoucherRequest(
  string Code
) : IRequest<ActionResponse>;