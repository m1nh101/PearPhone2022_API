using Core.Entities.Payments;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Users;

public class ShippingAddress : ModifierEntity
{
  private ShippingAddress() {}

  public ShippingAddress(string address, string city, AddressType type)
  {
    if(string.IsNullOrEmpty(address))
      throw new ArgumentNullException(nameof(address), "Địa chỉ không được trống");

    if(string.IsNullOrEmpty(city))
      throw new ArgumentNullException(nameof(city), "Thành phố không được để trống");

    Address = address;
    City = city;
    Type = type;
  }

  /// <summary>
  /// get or set address
  /// </summary>
  public string Address { get; private set; } = string.Empty;

  public string City { get; private set; } = string.Empty;

  /// <summary>
  /// get or set type of address
  /// </summary>
  public AddressType Type { get; private set; } = AddressType.Home;

  public Status Status { get; private set; } = Status.Active;

  /// <summary>
  /// get or set user id
  /// </summary>
  public string UserId { get; private set; } = string.Empty;
  public virtual User? User { get; private set; }

  public virtual ICollection<Receipt>? Receipts { get; set; }

  public void Update(string address, AddressType type)
  {
    Address = address;
    Type = type;
  }

  public void Delete() => Status = Status.None;
}
