using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Auth.UpdatePassword;

public sealed record UpdatePasswordRequest(
  string OldPassword,
  string NewPassword,
  string ConfirmPassword
) : IRequest<ActionResponse>;