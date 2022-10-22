using System.Net;
namespace Core.Interfaces;

public record ActionResponse(
  HttpStatusCode StatusCode,
  string Message,
  object? Data,
  object? Errors
);