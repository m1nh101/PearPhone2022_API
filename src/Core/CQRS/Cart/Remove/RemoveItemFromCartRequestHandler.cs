using Core.Helpers.Extensions;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Cart.Remove;

public sealed class RemoveItemFromCartRequestHandler
  : IRequestHandler<RemoveItemFromCartRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly ICurrentUser _user;

  public RemoveItemFromCartRequestHandler(IAppDbContext context, ICurrentUser user)
  {
    _context = context;
    _user = user;
  }

  public async Task<ActionResponse> Handle(RemoveItemFromCartRequest request, CancellationToken cancellationToken)
  {
    var order = await _context.Orders.CurrentOrder(_user.Id);

    var phoneStock = await _context.Stocks.AsNoTracking().FirstOrDefaultAsync(e => e.Id == request.ProductId);

    if(phoneStock == null)
      throw new NullReferenceException();

    double TotalOrderPrice = order.RemoveItem(request.ItemId, phoneStock.Price);

    _context.Orders.Update(order);

    await _context.Commit();

    var response = new RemovedItemFromCartResponse(TotalOrderPrice);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Xóa sản phẩm khỏi giỏ hàng thành công")
      .WithData(response);
  }
}
