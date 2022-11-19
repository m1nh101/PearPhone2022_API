using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Add;

public sealed record AddItemToCartRequest(
	int ProductId,
	int Quantity,
	int StockId
) : IRequest<ActionResponse>;