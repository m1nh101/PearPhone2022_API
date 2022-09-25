using Core.Entities.Orders;
using Core.Entities.Users;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities;

public class Receipt : ModifierEntity
{
  /// <summary>
  /// get or set user who sell product
  /// </summary>
  public string Seller { get; set; } = string.Empty;

  /// <summary>
  /// get or set of receipt
  /// </summary>
  public Status Status { get; set; } = Status.None;

  /// <summary>
  /// get or set description for receipt
  /// </summary>
  public string Description { get; set; } = string.Empty;

  //navigation and foreign key
  public int OrderId { get; set; }
  public virtual Order? Order { get; set; }

  /// <summary>
  /// get or set shipping address id
  /// </summary>
  public int AddressId { get; set; }
  public virtual ShippingAddress? Address { get; set; }

}