using Core.Interfaces;
using MediatR;

public sealed record GetListPhoneRequest(
  string? Branch,
  int RAM,
  string Capacity,
  int pageIndex = 1
) : IRequest<ActionResponse>;
