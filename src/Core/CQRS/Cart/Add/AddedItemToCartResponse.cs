namespace Core.CQRS.Cart.Add;

public sealed record AddedItemToCartResponse(
	int Quantity,
	double TotalOrderPrice,
	double TotalItemPrice
);