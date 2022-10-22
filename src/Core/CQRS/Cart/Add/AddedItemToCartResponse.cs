namespace Core.CQRS.Cart.Add;

public sealed record AddedItemToCartResponse(
	int Quantity,
	int Total,
	int DiscountPrice
);