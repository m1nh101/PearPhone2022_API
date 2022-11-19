namespace Core.CQRS.Cart.Get;

public sealed record ItemInCart
{
	public int ItemId { get; init; }
	public int Quanttiy { get; init; }
	public int ProductId { get; init; }
	public string ProductName { get; init; } = null!;
	public double Total { get; init; }
	public string ProductImage { get; init; } = null!;
}

public sealed record GetCurrentOrderResponse(
	double Total,
	IEnumerable<ItemInCart> Items
);