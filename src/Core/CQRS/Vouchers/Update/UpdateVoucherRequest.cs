using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.Vouchers.Update;

public record UpdateVoucherRequest(
  int Id,
  string Name,
  int TimesUse,
  VoucherType Type,
  DateTime EffectiveDate,
  DateTime ExpiredDate
) : IRequest<ActionResponse>;