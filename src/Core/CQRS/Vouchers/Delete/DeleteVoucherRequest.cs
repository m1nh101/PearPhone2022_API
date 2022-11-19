using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Vouchers.Delete;

public sealed record DeleteVoucherRequest(
  int Id
) : IRequest<ActionResponse>;