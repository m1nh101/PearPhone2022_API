using Core.CQRS.Auth.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public class RegisterNewUser : IRequest<CommonResponse<UserResponse>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string RepeatPassword { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string Email { get; set; } = string.Empty;
}