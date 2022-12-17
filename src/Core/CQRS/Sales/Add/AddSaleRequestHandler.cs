using System.Security.AccessControl;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Add;

public class AddSaleRequestHandler : IRequestHandler<AddSaleRequest, ActionResponse>
{
  public readonly IAppDbContext _context;

  public AddSaleRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(AddSaleRequest request, CancellationToken cancellationToken)
  { 
    var sale = new Sale(request.Effective, request.Expired, request.Discount);

    await _context.Sales.AddAsync(sale);
    
    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công");
  }
}