using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Add;

public sealed record AddSaleRequest(
    IEnumerable<int> Products,
    DateTime Effective,
    DateTime Expired,
    int Discount
) : IRequest<ActionResponse>;
