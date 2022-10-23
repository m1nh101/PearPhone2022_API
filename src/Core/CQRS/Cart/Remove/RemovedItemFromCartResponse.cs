namespace Core.CQRS.Cart.Remove;

public sealed record RemovedItemFromCartResponse(
  double TotalOrderPrice
);