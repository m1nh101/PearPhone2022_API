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
    // var detail = new PhoneDetail(request.Detail.Battery, request.Detail.Screen, request.Detail.OS,
    //     request.Detail.Charger, request.Detail.Camera, request.Detail.Audio, request.Detail.Security);
    // var stocks = request.Stocks
    //     .Select(e => new Stock(e.Quantity, e.Price, e.RAM, e.Capacity, new Color(e.Color.Name, e.Color.RGB), detail));

    // var phone = new Phone(request.Name, request.Branch)
    //   .WithStocks(stocks)
    //   .WithImages(request.Images);

    // await _context.Phones.AddAsync(phone);

    // await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công")
      .WithData(request);
  }
}