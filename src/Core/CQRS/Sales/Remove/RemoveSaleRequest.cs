using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Sales.Remove;

public sealed record RemoveSaleRequest(
    int saleId
) : IRequest<ActionResponse>;
