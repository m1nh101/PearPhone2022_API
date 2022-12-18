using Core.Entities.Orders;
using Core.Helpers;
using Core.Interfaces;
using Core.Helpers.Extensions;
using MediatR;
using Core.Specifications;

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

    var phoneStock = await Query.Find(_context.Stocks, new PhoneStockSpecification(request.StockId), QueryState.NoTracking);

    if(phoneStock.Quantity < request.Quantity)
      throw new ArgumentOutOfRangeException("quantity is greater than product have in stock");

    Item item = new(phoneStock!);

    var sale = phoneStock.Phone!.Sale;

    if(sale != null && sale.Status == Shared.Enums.Status.Active)
      item.Price = Calculator.DiscountPrice(phoneStock.Price, sale.Discount);

    double totalItemPrice = Calculator.TotalPrice(request.Quantity, item.Price);

    double totalOrderPrice = order!.AddItem(request.Quantity, phoneStock!, item.Price);

    _context.Orders.Update(order);

    await _context.Commit();

    var responseData = new AddedItemToCartResponse(request.Quantity, totalOrderPrice, totalItemPrice);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thêm sản phẩm vào giỏ thành công")
      .WithData(responseData);
  }
}