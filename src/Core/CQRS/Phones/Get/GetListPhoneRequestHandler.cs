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

  public Task<ActionResponse> Handle(GetListPhoneRequest request, CancellationToken cancellationToken)
  {
    var rawQuery = _context.Phones
      .Include(e => e.Images.Take(1))
      .Include(e => e.Stocks.Take(1))
      .AsNoTracking();
      
    var filter = QueryPhone(request, rawQuery)
      .Select(e => new GetListResponse(e.Id, e.Name, e.Stocks.First().Price, e.Stocks.First().SalePrice, e.Images.First().Url));;

    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành công")
      .WithData(filter);

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
