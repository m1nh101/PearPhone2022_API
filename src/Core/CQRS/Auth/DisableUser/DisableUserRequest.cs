using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Auth.DisableUser;

public sealed record DisableUserRequest : IRequest<ActionResponse>;