namespace Core.CQRS.Cart.ApplyVoucher;

public sealed record ApplyVoucherResponse(
  double Total,
  double Discount
);
