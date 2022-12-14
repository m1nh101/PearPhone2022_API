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
    Status = Shared.Enums.Status.Inprocess;
  }

  public double AddItem(int quantity, Stock phoneStock, double price)
  {
    double totalItemPrice = 0;
    var itemInOrder = _items.FirstOrDefault(e => e.StockId == phoneStock.Id);

    if(itemInOrder == null)
    {
      Item item = new(phoneStock);
      item.Price = price;
      _items.Add(item);
      totalItemPrice = item.UpdateQuantity(quantity);
    } else
    {
      Total -= itemInOrder.Total();

      itemInOrder.Price = price;
      totalItemPrice = itemInOrder.UpdateQuantity(quantity);
    }

    Total += totalItemPrice;

    return Total;
  }

  public double RemoveItem(int id)
  {
    Item? item = _items.FirstOrDefault(e => e.Id == id);

    if(item == null)
      throw new NullReferenceException();

    double totalItemPrice = TotalPriceCalculate(item.Quantity, item.Price);

    Total -= totalItemPrice;

    return Total;
  }

  public double UpdateItemInCart(int id, int quantiy, double price)
  {
    var item = _items.FirstOrDefault(e => e.Id == id);

    if(item == null)
      throw new NullReferenceException();

    if(item.Price != price)
      item.Price = price;

    double totalItemPriceBeforeUpdatedQuantity = TotalPriceCalculate(item.Quantity, price);
    double totalItemPriceAfterUpdatedQuantity = item.UpdateQuantity(quantiy);
    double differentPriceAfterQuantityChanged = totalItemPriceAfterUpdatedQuantity - totalItemPriceBeforeUpdatedQuantity;

    bool isIncreasingQuantity = totalItemPriceBeforeUpdatedQuantity < totalItemPriceAfterUpdatedQuantity;
    
    if(isIncreasingQuantity)
      Total -= differentPriceAfterQuantityChanged;
    else
      Total += differentPriceAfterQuantityChanged;

    return Total;
  }
} 