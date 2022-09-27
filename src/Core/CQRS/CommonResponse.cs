using System.Net;

namespace Core.CQRS;

public class CommonResponse<TModel>
{
  public HttpStatusCode StatusCode { get; set; }
  public string Message { get; set; } = string.Empty;
  public object? Errors { get; set; }
  public TModel? Data { get; set; }
  public DateTime RequestCompletedAt { get; } = DateTime.UtcNow;
}