namespace Core.CQRS.Cart.Update;

public sealed record UpdatedItemQuantityResponse(
  double TotalItemPrice,
  double TotalOrderPrice,
  int Quantity
);