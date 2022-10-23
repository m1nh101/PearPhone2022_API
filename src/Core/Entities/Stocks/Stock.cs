using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Stocks;

public partial class Stock : ModifierEntity
{
  /// <summary>
  /// get or set quantity of product in stock
  /// </summary>
  public int Quantity { get; private set; }

  public double Price { get; private set; }

  public Status Status { get; private set; } = Status.None;
}
