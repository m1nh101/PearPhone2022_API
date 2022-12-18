using Core.CQRS.Phones.Add;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Phones.GetDetail;

public sealed class GetPhoneDetailRequestHandler
  : IRequestHandler<GetPhoneDetailRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetPhoneDetailRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(GetPhoneDetailRequest request, CancellationToken cancellationToken)
  {
    var phone = await Query.Find(_context.Phones, new PhoneSpecification(request.Id), QueryState.NoTracking);

    var detail = new DetailPayload(phone.Detail!.Battery, phone.Detail.Screen, phone.Detail.OS,
        phone.Detail.Charger, phone.Detail.Camera, phone.Detail.Audio, phone.Detail.Security!,
        phone.Detail.CPU, phone.Detail.RAM, phone.Detail.Connection);

    var stocks = phone.Stocks.Select(e => new PhoneStock(e.Id, e.Price, e.Capacity, e.Color!.Name, e.Color.Url, e.Quantity));

    var images = phone.Images.Select(e => e.Url);
    
    var data = new PhoneResponse(phone.Name, phone.Branch, stocks, detail, images);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Ok").WithData(data);
  }
}