using Core.Entities.Orders;
using Core.Helpers;
using Core.Interfaces;
using Core.Helpers.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Cart.Add;

public sealed class AddItemToCartRequestHandler
  : IRequestHandler<AddItemToCartRequest, ActionResponse>
{
	private readonly IAppDbContext _context;
  private readonly ICurrentUser _user;

  public AddItemToCartRequestHandler(IAppDbContext context, ICurrentUser user)
  {
    _context = context;
    _user = user;
  }

  public async Task<ActionResponse> Handle(AddItemToCartRequest request, CancellationToken cancellationToken)
  {
    var order = await _context.Orders.CurrentOrder(_user.Id);

    var phoneStock = await _context.Stocks.FirstOrDefaultAsync(e => e.Id == request.ProductId);

    bool validRequestParameter = order == null || phoneStock == null;
      
    if(!validRequestParameter)
      throw new NullReferenceException();

    Item item = new(phoneStock!);

    double totalItemPrice = Calculator.TotalPrice(request.Quantity, phoneStock!.Price);

    double totalOrderPrice = order!.AddItem(request.Quantity, phoneStock!);

    _context.Orders.Update(order);

    await _context.Commit();

    var responseData = new AddedItemToCartResponse(request.Quantity, totalOrderPrice, totalItemPrice);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm sản phẩm vào giỏ thành công", responseData, default);
  }
}