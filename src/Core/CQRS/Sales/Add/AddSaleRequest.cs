using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Add;

public sealed record AddSaleRequest(
    IEnumerable<int> Products,
    DateTime Effective,
    DateTime Expired,
    double Discount
) : IRequest<ActionResponse>;
