using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Add;

public sealed record AddSaleRequest(
    int[]? Phones,
    DateTime Effective,
    DateTime Expired,
    int Discount
) : IRequest<ActionResponse>;
