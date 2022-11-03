using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record GetListPhoneRequest(
  string? Branch,
  int RAM,
  string Capacity,
  int pageIndex = 1
) : IRequest<ActionResponse>;

public sealed record GetListResponse(
  int Id,
  string Name,
  double Price,
  string Image
);

public sealed class GetListPhoneRequestHandler
  : IRequestHandler<GetListPhoneRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetListPhoneRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  private static readonly int recordPerPage = 20;

  public Task<ActionResponse> Handle(GetListPhoneRequest request, CancellationToken cancellationToken)
  {
    int skipRecord = recordPerPage * (request.pageIndex - 1);

    var query = _context.Phones
      .Include(e => e.Images.First())
      .Include(e => e.Stocks.First())
      .Skip(skipRecord)
      .Take(recordPerPage)
      .Select(e => new GetListResponse(e.Id, e.Name, e.Stocks.First().Price, e.Images.First().Url))
      .AsNoTracking();

    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành công", query, default);

    return Task.FromResult(response);
  }
}
