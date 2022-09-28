using Core.Interfaces;
using System.Security.Claims;

namespace API.Helpers;

public class CurrentUser : ICurrentUser
{
  private readonly IHttpContextAccessor _http;

  public CurrentUser(IHttpContextAccessor http)
  {
    _http = http;
  }

  public string Id => _http.HttpContext!.User!.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}