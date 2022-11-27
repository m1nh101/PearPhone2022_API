using System.Net;
namespace Core.Interfaces;

public class ActionResponse
{
  public ActionResponse(HttpStatusCode statusCode, string message)
  {
    StatusCode = statusCode;
    Message = message;
  }

  public HttpStatusCode StatusCode { get; init; }
  public string Message { get; init; }
  public object? Data { get; set; }
  public object? Error { get; set; }

  public ActionResponse WithError(object error)
  {
    Error = error;
    return this;
  }

  public ActionResponse WithData(object data)
  {
    Data = data;
    return this;
  }
}