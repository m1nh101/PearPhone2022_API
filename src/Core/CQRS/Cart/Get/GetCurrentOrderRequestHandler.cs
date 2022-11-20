using Core.Helpers;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Cart.Get;

public sealed class GetCurrentOrderRequestHandler
  : IRequestHandler<GetCurrentOrderRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly ICurrentUser _user;

  public GetCurrentOrderRequestHandler(IAppDbContext context, ICurrentUser user)
  {
    _context = context;
    _user = user;
  }

  public Task<ActionResponse> Handle(GetCurrentOrderRequest request, CancellationToken cancellationToken)
  {
    var cart = _context.Orders
      .Include(e => e.Items)
      .ThenInclude(e => e.Stock)
      .ThenInclude(e => e.Phone)
      .ThenInclude(e => e.Images)
      .Select(e => new GetCurrentOrderResponse(e.Total,
        e.Items.Select(d => new ItemInCart {
          ItemId = d.Id,
          Quanttiy = d.Quantity,
          Total = Calculator.TotalPrice(d.Quantity, d.Stock.Price),
          ProductName = d.Stock.Phone.Name,
          ProductImage = d.Stock!.Phone!.Images.First()!.Url
        })))
      .AsNoTracking();
    
    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành công", cart, default);
    
    return Task.FromResult<ActionResponse>(response);
  }
}