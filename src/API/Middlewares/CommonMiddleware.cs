using System.Net;
using Core.Interfaces;

namespace API.Middlewares;

public class CommonMiddleware
{
  private readonly RequestDelegate _next;

  public CommonMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext http)
  {
    try
    {
      await _next(http);
    }
    catch(Exception ex)
    {
      var response = new ActionResponse(System.Net.HttpStatusCode.BadRequest, ex.Message, null, ex.Data);
      await http.Response.WriteAsJsonAsync(response);
    }
  }
}