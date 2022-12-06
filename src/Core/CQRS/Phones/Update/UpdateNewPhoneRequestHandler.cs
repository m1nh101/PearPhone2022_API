using Core.Entities.Phones;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

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
    var phone = Query.Get(_context.Phones, new PhoneSpecification(request.Id), false);
    
    var detail = new PhoneDetail(request.Detail.Battery, request.Detail.Screen, request.Detail.OS, request.Detail.RAM,
        request.Detail.Charger, request.Detail.Camera, request.Detail.Audio, request.Detail.Security, request.Detail.Connection);
    
    var stocks = from color in request.Colors
                 let colors = new Color(color.Name, color.Url)
                 from item in color.Stocks
                 let stock = new Stock(item.Quantity, item.Price, item.Capacity, colors)
                  .SetImeis(item.Imeis)
                  .WithId(item.Id)
                 select stock;

    phone.Update(request.Name, request.Branch).UpdateDetail(detail)
      .UpdateStock(stocks);
    
    await _context.Commit();
    
    return new ActionResponse(System.Net.HttpStatusCode.OK, "Sửa thành công")
      .WithData(request);
  }
}