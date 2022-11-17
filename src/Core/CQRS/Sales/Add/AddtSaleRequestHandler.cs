using System.Security.AccessControl;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Add;

public sealed record AddSaleReques(
    int Id,
    DateTime Effective,
    DateTime Expired,
    double Discount,
    DateTime CreateAt,
    DateTime UpdateAt,
    string CreateBy,
    string UpdateBy
) : IRequest<ActionResponse>;

public class AddtSaleRequestHandler : IRequestHandler<AddSaleReques, ActionResponse>
{
    public readonly IAppDbContext _context;

    public AddtSaleRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse> Handle(AddSaleReques request, CancellationToken cancellationToken)
    {
        
        var sale = new Sale
        {
            Effective = request.Effective,
            Expired = request.Expired,
            Discount = request.Discount,
            CreatedAt = request.CreateAt,
            UpdatedAt = request.UpdateAt,
            CreatedBy = request.CreateBy,
            UpdatedBy = request.UpdateBy
        };
        await _context.Sales.AddAsync(sale);
        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công", sale, default);
    }
}