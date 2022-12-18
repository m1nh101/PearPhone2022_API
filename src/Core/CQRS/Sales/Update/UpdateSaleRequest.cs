using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Update;

public sealed record UpdateSaleRequest(
    int Id,
    DateTime Effective,
    DateTime Expired,
    int Discount,
    int[]? AddProducts,
    int[]? RemoveProducts
) : IRequest<ActionResponse>;
