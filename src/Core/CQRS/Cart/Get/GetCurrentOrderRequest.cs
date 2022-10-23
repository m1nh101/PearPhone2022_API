using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Get;

public sealed record GetCurrentOrderRequest : IRequest<ActionResponse>;