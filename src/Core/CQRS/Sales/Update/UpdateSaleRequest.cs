using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Update;

public sealed record UpdateSaleRequest(
    int Id,
    DateTime Effective,
    DateTime Expired,
    int Discount,
    IEnumerable<int>? AddProducts,
    IEnumerable<int>? RemoveProducts
) : IRequest<ActionResponse>;
