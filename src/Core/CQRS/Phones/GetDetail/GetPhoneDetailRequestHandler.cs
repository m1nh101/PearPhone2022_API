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

    var colors = phone.Stocks.Select(e => new PhoneColor(e.ColorId, e.Color!.Url, e.Color.Name));

    var capacitities = phone.Stocks.Select(e => e.Capacity);

    var price = phone.Stocks.First().Price;

    var data = new PhoneResponse(phone.Name, price, phone.Branch, colors, capacitities, detail);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Ok").WithData(data);
  }
}