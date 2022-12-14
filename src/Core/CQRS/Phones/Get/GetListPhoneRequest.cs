using Core.Interfaces;
using MediatR;

public sealed record GetListPhoneRequest(
  string? Name,
  string? Branch,
  int RAM,
  int Capacity
) : IRequest<ActionResponse>;