using System.Net;
using Core.Interfaces;

namespace Core.CQRS.Auth.Login;

public sealed record SuccessLoginResponse(
	string Username,
	string Email,
	string Name,
	string Token
);