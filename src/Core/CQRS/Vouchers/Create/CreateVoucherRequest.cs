using Core.Interfaces;
using MediatR;
using Shared.Enums;

namespace Core.CQRS.Vouchers.Create;

public record CreateVoucherRequest(
  string Name,
  int TimesUse,
  VoucherType Type,
  DateTime EffectiveDate,
  DateTime ExpiredDate
) : IRequest<ActionResponse>;