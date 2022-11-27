using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Core.CQRS.Sales.Remove;

public class RemoveSaleRequestHandler : IRequestHandler<RemoveSaleRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public RemoveSaleRequestHandler(IAppDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResponse> Handle(RemoveSaleRequest request, CancellationToken cancellationToken)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(c => c.Id == request.saleId);
        if (sale == null) throw new NullReferenceException();

        sale.Delete();
        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Xóa thành công");
    }
}