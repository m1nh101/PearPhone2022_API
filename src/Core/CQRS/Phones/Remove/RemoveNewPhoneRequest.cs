using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Phones.Remove;

public sealed record RemoveNewPhoneRequest(
    int phoneId
) : IRequest<ActionResponse>;
