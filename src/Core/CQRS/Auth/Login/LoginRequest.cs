using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Auth.Login;

public sealed record LoginRequest(
	string Username,
	string Password
) : IRequest<ActionResponse>;