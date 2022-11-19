using Shared.Enums;

namespace Core.CQRS.Vouchers.Create;

public sealed record CreatedVoucherResponse(
  int Id,
  string Name,
  int TimesUse,
  VoucherType Type,
  DateTime EffectiveDate,
  DateTime ExpiredDate
) : CreateVoucherRequest(Name, TimesUse, Type, EffectiveDate, ExpiredDate);