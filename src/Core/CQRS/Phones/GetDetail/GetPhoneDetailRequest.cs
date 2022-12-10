using Core.CQRS.Phones.Add;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.GetDetail;

public sealed record GetPhoneDetailRequest(
  int Id
) : IRequest<ActionResponse>;

public sealed record PhoneResponse(
  string Name,
  double Price,
  string Branch,
  IEnumerable<PhoneColor> Colors,
  IEnumerable<int> Capacities,
  DetailPayload Detail
);

public sealed record PhoneColor(
  int Id,
  string Url,
  string Name
);