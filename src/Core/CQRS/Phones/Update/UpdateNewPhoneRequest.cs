using Core.CQRS.Phones.Add;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Update
{
    public sealed record UpdateNewPhoneRequest(
        int PhoneId,
        string Name,
        string Branch,
        IEnumerable<ColorPayload> Colors,
        IEnumerable<StockPayload> Stocks,
        DetailPayload Detail
    ) : IRequest<ActionResponse>;

    public sealed record ColorPayload(
        int Id,
        string Url,
        string Name,
        IEnumerable<StockPayload> Stocks
    );

    public sealed record DetailPayload(
        string Battery,
        string Screen,
        string OS,
        string Charger,
        string Camera,
        string Audio,
        string Security,
        string CPU,
        int RAM,
        string Connection
    );
    public sealed record StockPayload(
        int Quantity,
        double Price,
        int Capacity
    );
}