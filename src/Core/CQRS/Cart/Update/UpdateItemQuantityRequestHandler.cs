using Core.Helpers;
using Core.Helpers.Extensions;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Cart.Update;

public sealed class UpdateItemQuantityRequestHandler
  : IRequestHandler<UpdateItemQuantityRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly ICurrentUser _user;

  public UpdateItemQuantityRequestHandler(IAppDbContext context, ICurrentUser user)
  {
    _context = context;
    _user = user;
  }

  public async Task<ActionResponse> Handle(UpdateItemQuantityRequest request, CancellationToken cancellationToken)
  {
    var order = await _context.Orders.CurrentOrder(_user.Id);

    var phoneStock = await Query.Find(_context.Stocks, new PhoneStockSpecification(request.ProductId), QueryState.NoTracking);

    double totalItemPrice = Calculator.TotalPrice(request.Quantity, phoneStock.Price);
    double totalOrderPrice = order.UpdateItemInCart(request.ItemId, request.Quantity, phoneStock.Price);

    _context.Orders.Update(order);

    await _context.Commit();

    var response = new UpdatedItemQuantityResponse(totalItemPrice, totalOrderPrice, request.Quantity);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Cập nhật giỏ hàng thành công")
      .WithData(response);
  }
}
