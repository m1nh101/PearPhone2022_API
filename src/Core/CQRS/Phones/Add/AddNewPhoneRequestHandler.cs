using Core.Entities.Phones;
using Core.Interfaces;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Add;
public sealed record ColorPayload(
    int Id,
    string RGB,
    string Name
);

public sealed record DetailPayload(
    int Id,
    string Bettery,
    string Screen,
    string OS,
    string Charger,
    string Camera,
    string Audio,
    string Security
);
public sealed record StockPayload(
    ColorPayload Color,
    DetailPayload Detail,
    int RAM,
    int Quantity,
    double Price,
    int Capacity
);

public sealed record AddNewPhoneRequest(
    string Name,
    string CPU,
    IEnumerable<StockPayload> Stocks,
    IEnumerable<string> Images
) : IRequest<ActionResponse>;

public sealed class AddNewPhoneRequestHandler:IRequestHandler<AddNewPhoneRequest, ActionResponse>
{
    private readonly IAppDbContext _context;

    public AddNewPhoneRequestHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse> Handle(AddNewPhoneRequest request, CancellationToken cancellationToken)
    {
        var stocks = request.Stocks.Select(e => new Stock(e.Quantity, e.Price, e.RAM, e.Capacity, e.Color.Id, e.Detail.Id) {
            ColorId = e.Color.Id,
            PhoneDetailId = e.Detail.Id
        });

        var phone = new Phone
        {
            Name = request.Name
        }.AddStock(stocks);

        await _context.Phones.AddAsync(phone);

        await _context.Commit();

        return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm thành công", phone,
            default);
    }
}