using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Stocks;

public partial class Stock : ModifierEntity
{
  /// <summary>
  /// get or set quantity of product in stock
  /// </summary>
  public int Quantity { get; set; }

  public Status Status { get; set; } = Status.None;
}
