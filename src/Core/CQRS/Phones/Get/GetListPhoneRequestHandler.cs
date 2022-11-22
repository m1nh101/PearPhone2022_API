using Core.Entities.Phones;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

  public IQueryable<Phone> QueryPhone(GetListPhoneRequest request, IQueryable<Phone> source)
  {
    if(!string.IsNullOrEmpty(request.Name))
      source = source.Where(e => e.Name.Contains(request.Name));
    
    if(request.RAM == 0)
      source = source.Where(e => e.Stocks.Any(e => e.RAM == request.RAM));

    if(request.Capacity == 0)
      source = source.Where(e => e.Stocks.Any(e => e.Capacity == request.Capacity));

    return source;
  }
}
