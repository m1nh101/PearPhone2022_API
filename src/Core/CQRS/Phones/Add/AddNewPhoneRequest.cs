using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Add;

public sealed record AddNewPhoneRequest(
    string Name,
    string CPU,
    IEnumerable<StockPayload> Stocks,
    DetailPayload Detail,
    IEnumerable<string> Images
) : IRequest<ActionResponse>;

public sealed record ColorPayload(
    int Id,
    string RGB,
    string Name
);

public sealed record DetailPayload(
    string Battery,
    string Screen,
    string OS,
    string Charger,
    string Camera,
    string Audio,
    string Security
);
public sealed record StockPayload(
    ColorPayload Color,
    int RAM,
    int Quantity,
    double Price,
    int Capacity
);