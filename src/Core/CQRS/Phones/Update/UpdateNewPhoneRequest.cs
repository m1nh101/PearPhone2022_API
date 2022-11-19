using Core.CQRS.Phones.Add;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Update
{
    public sealed record UpdateNewPhoneRequest(
        int PhoneId,
        string Name,
        string CPU,
        IEnumerable<StockPayload> Stocks,
        DetailPayload Detail
    ) : IRequest<ActionResponse>;
}