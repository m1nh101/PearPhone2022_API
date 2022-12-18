using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
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

    bool hasPhone = request.Phones != null && request.Phones.Length > 0;

    if(hasPhone)
    {
      var phones = Query.All(_context.Phones, new PhoneWithSaleSpecification(request.Phones!), QueryState.Tracking);

      foreach(var phone in phones)
        phone.SetSaleValue(sale);
    }

    await _context.Sales.AddAsync(sale);
    
    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công");
  }
}