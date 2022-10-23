using Core.Entities.Phones;
using Core.Helpers;
using Shared.Interfaces;

namespace Core.Entities.Orders;

public partial class Order : IAggregateRoot
{
  private Func<int, double, double> TotalPriceCalculate;

  public Order()
  {
    TotalPriceCalculate = Calculator.TotalPrice;
  }

  public double AddItem(int quantity, Stock phoneStock)
  {
    double totalItemPrice = 0;
    Item? itemInOrder = _items.FirstOrDefault(e => e.StockId == phoneStock.Id);

    if(itemInOrder == null)
    {
      Item item = new(phoneStock);
      totalItemPrice = item.UpdateQuantity(quantity);
    } else
      totalItemPrice = itemInOrder.UpdateQuantity(quantity);

    Total += totalItemPrice;

    return Total;
  }

  public double RemoveItem(int id, double price)
  {
    Item? item = _items.FirstOrDefault(e => e.Id == id);

    if(item == null)
      throw new NullReferenceException();

    double totalItemPrice = TotalPriceCalculate(item.Quantity, price);

    Total -= totalItemPrice;

    return Total;
  }

  public double UpdateItemInCart(int id, int quantiy, double price)
  {
    Item? item = _items.FirstOrDefault(e => e.Id == id);

    if(item == null)
      throw new NullReferenceException();

    double totalItemPriceBeforeUpdateQuantity = TotalPriceCalculate(item.Quantity, price);
    double totalItemPriceAfterUpdatedQuantity = item.UpdateQuantity(quantiy);
    double differentPriceAfterQuantityChanged = totalItemPriceAfterUpdatedQuantity - totalItemPriceBeforeUpdateQuantity;

    bool isIncreasingQuantity = totalItemPriceBeforeUpdateQuantity < totalItemPriceAfterUpdatedQuantity;
    
    if(isIncreasingQuantity)
      Total -= differentPriceAfterQuantityChanged;
    else
      Total += differentPriceAfterQuantityChanged;

    return Total;
  }
}