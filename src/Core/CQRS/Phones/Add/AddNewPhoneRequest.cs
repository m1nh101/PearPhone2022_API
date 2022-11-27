using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Add;

public record AddNewPhoneRequest(
  string Name,
  string Branch,
  IEnumerable<ColorPayload> Colors,
  DetailPayload Detail,
  IEnumerable<string> Images
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
  int Id,
  int Quantity,
  double Price,
  int Capacity
);