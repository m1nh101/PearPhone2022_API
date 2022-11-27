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

    var rawQuery = _context.Phones
      .Include(e => e.Images.Take(1))
      .Include(e => e.Stocks.Take(1))
      .AsNoTracking();

    var filter = QueryPhone(request, rawQuery);

    var pagination = filter
      .Skip(skipRecord)
      .Take(recordPerPage)
      .Select(e => new GetListResponse(e.Id, e.Name, e.Stocks.First().Price, e.Images.First().Url));

    // var query = _context.Phones
    //   .Include(e => e.Images.Take(1))
    //   .Include(e => e.Stocks.Take(1))
    //   .Skip(skipRecord)
    //   .Take(recordPerPage)
    //   .Select(e => new GetListResponse(e.Id, e.Name, e.Stocks.First().Price, e.Images.First().Url))
    //   .AsNoTracking();

    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành công")
      .WithData(pagination);

    return Task.FromResult(response);
  }

  private IQueryable<Phone> QueryPhone(GetListPhoneRequest request, IQueryable<Phone> source)
  {
    if(!string.IsNullOrEmpty(request.Name))
      source = source.Where(e => e.Name.Contains(request.Name));
    
    if(request.RAM != 0)
      source = source.Where(e => e.Detail!.RAM == request.RAM);

    if(request.Capacity != 0)
      source = source.Where(e => e.Stocks.Any(e => e.Capacity == request.Capacity));

    if(!string.IsNullOrEmpty(request.Branch))
      source = source.Where(e => e.Name.Contains(request.Branch));

    return source;
  }
}
