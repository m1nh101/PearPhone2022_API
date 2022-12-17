using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

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
        var sale = await Query.Find(_context.Sales, new SaleSpecification(request.Id), QueryState.Tracking);

        sale.Delete();

        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Xóa thành công");
    }
}