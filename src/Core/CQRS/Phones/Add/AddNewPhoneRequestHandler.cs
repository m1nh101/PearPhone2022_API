using Core.Entities.Phones;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Add;

public sealed class AddNewPhoneRequestHandler : IRequestHandler<AddNewPhoneRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public AddNewPhoneRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(AddNewPhoneRequest request, CancellationToken cancellationToken)
  {
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

        var phone = new Phone(request.Name, request.Branch)
          .WithStocks(stocks)
          .WithImages(request.Images);

        await _context.Phones.AddAsync(phone);

        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công")
      .WithData(request);
  }
}