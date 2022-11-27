using Core.CQRS.Phones.Add;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Update;

public sealed record UpdateNewPhoneRequest(
  int Id,
  string Name,
  string Branch,
  IEnumerable<ColorPayload> Colors,
  DetailPayload Detail
) : AddNewPhoneRequest(Name, Branch, Colors, Detail, Array.Empty<string>()), IRequest<ActionResponse>;

// public sealed record ColorPayload(
//   int Id,
//   string Url,
//   string Name,
//   IEnumerable<StockPayload> Stocks
// );

// public sealed record StockPayload(
//   int Quantity,
//   double Price,
//   int Capacity
// );