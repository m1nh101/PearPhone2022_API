using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Update;

public sealed record UpdateItemQuantityRequest(
	int ItemId,
	int Quantity
) : IRequest<ActionResponse>;