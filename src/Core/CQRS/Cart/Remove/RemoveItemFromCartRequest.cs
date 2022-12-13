using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Remove;

public sealed record RemoveItemFromCartRequest(
	int ItemId,
	int ProductId
) : IRequest<ActionResponse>;