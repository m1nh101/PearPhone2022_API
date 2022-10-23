using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Update;

public sealed record UpdateItemQuantityRequest(
	int ItemId,
	int ProductId,
	int Quantity
) : IRequest<ActionResponse>;