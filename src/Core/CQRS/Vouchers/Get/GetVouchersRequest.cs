using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Vouchers.Get;

public sealed record GetVouchersRequest : IRequest<ActionResponse>;