using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Update;

public sealed record UpdateSaleRequest(
    int saleId,
    DateTime Effective,
    DateTime Expired,
    double Discount
) : IRequest<ActionResponse>;
