using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Remove;

public sealed record RemoveItemFromCartRequest(
	int ItemId,
	int ProductId
) : IRequest<ActionResponse>;