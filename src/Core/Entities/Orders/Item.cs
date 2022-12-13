using Core.Entities.Phones;
using Core.Exceptions;
using Core.Helpers;
using Shared.Bases;

namespace Core.Entities.Orders;

public class Item : ModifierEntity
{
	private Func<int, double, double> TotalItemPriceCalculate;

	private Item()
	{
		TotalItemPriceCalculate = Calculator.TotalPrice;
	}

  public Item(Stock stock, int quantity)
  {
    StockId = stock.Id;
    Quantity = quantity;
    Price = stock.Price;
    TotalItemPriceCalculate = Calculator.TotalPrice;
  }

  public Item(Stock stock)
  {
		Stock = stock;
		TotalItemPriceCalculate = Calculator.TotalPrice;
  }

  /// <summary>
  /// get  quantity
  /// </summary>
  public int Quantity { get; private set; }

  public double Price { get; set; }

  public double UpdateQuantity(int quantity)
  {
    if (quantity <= 0)
      throw new InvalidNumberException($"{quantity} is invalid, value must be greater than zero");

    Quantity = quantity;

		return TotalItemPriceCalculate(quantity, Stock.Price);
  }

  /// <summary>
  /// get or set order id
  /// </summary>
  public int OrderId { get; private set; }

  /// <summary>
  /// get or set phone id
  /// </summary>
  public int StockId { get; private set; }

  /// <summary>
  /// get or set order object
  /// </summary>
  public virtual Order Order { get; private set; } = null!;

  /// <summary>
  /// get stock of phone object
  /// </summary>
  public virtual Stock Stock { get; private set; } = null!;
}