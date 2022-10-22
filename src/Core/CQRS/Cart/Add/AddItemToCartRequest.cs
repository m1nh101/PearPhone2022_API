using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Add;

public sealed record AddItemToCartRequest(
	int ProductId,
	int Quantity
) : IRequest<ActionResponse>;