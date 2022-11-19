namespace Core.CQRS.Vouchers.Get;

public sealed record GetVoucheRequestResponse(
  int Id,
  string Name,
  string Code,
  DateTime EffectiveDate,
  DateTime ExpiredDate,
  int TimesUse
);