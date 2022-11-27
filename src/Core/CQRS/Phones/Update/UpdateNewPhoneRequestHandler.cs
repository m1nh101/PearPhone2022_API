using Core.Entities.Phones;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Phones.Update;

public sealed class UpdateNewPhoneRequestHandler :
      IRequestHandler<UpdateNewPhoneRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public UpdateNewPhoneRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(UpdateNewPhoneRequest request, CancellationToken cancellationToken)
  {
    var phone = await _context.Phones.FirstOrDefaultAsync(c => c.Id == request.PhoneId);
    if (phone == null) throw new NullReferenceException();
    
    var detail = new PhoneDetail(request.Detail.Battery, request.Detail.Screen, request.Detail.OS, request.Detail.RAM,
        request.Detail.Charger, request.Detail.Camera, request.Detail.Audio, request.Detail.Security, request.Detail.Connection);
    
    List<Stock> stocks = new List<Stock>();
    foreach (var color in request.Colors)
    {
        var colors = new Color(color.Name, color.Url);
        foreach (var item in color.Stocks)
        {
            var stock = new Stock(item.Quantity, item.Price, item.Capacity, colors, detail);
            stocks.Add(stock);
        }
    }
    
    phone.UpdateStock(stocks);
    
    _context.Phones.Update(phone);
    await _context.Commit();
    
    return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công");
  }
}