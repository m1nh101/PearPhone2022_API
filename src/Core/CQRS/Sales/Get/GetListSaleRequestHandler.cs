using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

public sealed class GetListSaleRequestHandler : IRequestHandler<GetListSaleRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public GetListSaleRequestHandler(IAppDbContext context)
    {
        _context = context;
    }
    public Task<ActionResponse> Handle(GetListSaleRequest request, CancellationToken cancellationToken)
    {
        var list = _context.Sales.Select(c => new GetListSaleResponse(c.Id, c.Effective, c.Expired, c.Discount,
            c.CreatedAt, c.UpdatedAt, c.CreatedBy, c.UpdatedBy)).AsNoTracking();

        var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành Công", list, default);
        return Task.FromResult(response);
    }
}