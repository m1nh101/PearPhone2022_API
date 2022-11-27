using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Get;

public sealed record GetListSaleRequest : IRequest<ActionResponse>;

public sealed record GetListSaleResponse(
    int Id,
    DateTime Effective,
    DateTime Expired,
    double Discount,
    DateTime CreateAt,
    DateTime UpdateAt,
    string CreateBy,
    string UpdateBy
);

