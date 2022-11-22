using Core.Entities.Payments;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Orders;

public partial class Order : ModifierEntity
{
  /// <summary>
  /// get or set total price of order
  /// </summary>
  public double Total { get; private set; }

  /// <summary>
  /// get or set status of order
  /// </summary>
  public Status Status { get; private set; } = Status.Active;

  public Receipt MakeReceipt()
  {
    Receipt = new Receipt(this)
        .WithTotalPrice(Total);
    return Receipt;
  }
}