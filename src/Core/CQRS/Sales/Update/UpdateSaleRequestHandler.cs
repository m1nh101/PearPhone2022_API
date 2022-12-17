using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Sales.Update;

public class UpdateSaleRequestHandler :
	IRequestHandler<UpdateSaleRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public UpdateSaleRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(UpdateSaleRequest request, CancellationToken cancellationToken)
  {
    var sale = await Query.Find(_context.Sales, new SaleSpecification(request.Id), QueryState.Tracking);

    var payload = new Sale(request.Effective, request.Expired, request.Discount);

    sale.Update(payload);

    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công")
        .WithData(request);
  }
}