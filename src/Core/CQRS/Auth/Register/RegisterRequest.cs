using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Auth.Register;

public sealed record RegisterRequest(
	string Username,
	string Password,
	string Email,
	string FirstName,
	string LastName,
	string? MiddleName
) : IRequest<ActionResponse>;