﻿using Core.Entities.Stocks;
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

  public Item(Phone phone)
  {
		Phone = phone;
		TotalItemPriceCalculate = Calculator.TotalPrice;
  }

  /// <summary>
  /// get  quantity
  /// </summary>
  public int Quantity { get; private set; }

  public double UpdateQuantity(int quantity)
  {
    if (quantity <= 0)
      throw new InvalidNumberException($"{quantity} is invalid, value must be greater than zero");

    Quantity = quantity;

		return TotalItemPriceCalculate(quantity, Phone.Price);
  }

  /// <summary>
  /// get or set order id
  /// </summary>
  public int OrderId { get; private set; }

  /// <summary>
  /// get or set phone id
  /// </summary>
  public int PhoneId { get; private set; }

  /// <summary>
  /// get or set order object
  /// </summary>
  public virtual Order Order { get; private set; } = null!;

  /// <summary>
  /// get or set phone object
  /// </summary>
  public virtual Phone Phone { get; private set; } = null!;
}