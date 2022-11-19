using Core.Entities.Payments;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Users;

public class ShippingAddress : ModifierEntity
{
  /// <summary>
  /// get or set address
  /// </summary>
  public string Address { get; set; } = string.Empty;

  /// <summary>
  /// get or set type of address
  /// </summary>
  public AddressType Type { get; set; } = AddressType.Home;

  /// <summary>
  /// get or set user id
  /// </summary>
  public string UserId { get; private set; } = string.Empty;
  public virtual User? User { get; set; }

  public virtual ICollection<Receipt>? Receipts { get; set; }
}
