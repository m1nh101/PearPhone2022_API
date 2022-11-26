using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Sales.Update;

public class UpdateSaleRequestHandler : IRequestHandler<UpdateSaleRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public UpdateSaleRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse> Handle(UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(c => c.Id == request.saleId);
        if (sale == null) throw new NullReferenceException();
        
        sale.Effective = request.Effective;
        sale.Expired = request.Expired;
        sale.Discount = request.Discount;

        _context.Sales.Update(sale);
        await _context.Commit();
        
        return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công");
    }
}