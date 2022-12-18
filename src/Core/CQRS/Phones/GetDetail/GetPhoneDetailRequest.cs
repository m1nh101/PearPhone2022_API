using Core.CQRS.Phones.Add;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.GetDetail;

public sealed record GetPhoneDetailRequest(
  int Id
) : IRequest<ActionResponse>;

public sealed record PhoneResponse(
  string Name,
  string Branch,
  IEnumerable<PhoneStock> Stocks,
  DetailPayload Detail,
  IEnumerable<string> Images
);

public sealed record PhoneStock(
  int Id,
  double Price,
  int Capacity,
  string ColorName,
  string Thumbnail,
  int Stock
);