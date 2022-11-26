using Shared.Interfaces;

namespace Core.Entities.Users;

public partial class User : IAggregateRoot
{
  public string GetFullName() => $"{FirstName}{(string.IsNullOrEmpty(MiddleName) ? string.Empty : $" {MiddleName}")} {LastName}";
  public void SetStatus(bool isActive) => Active = isActive;

  public void CancelReceiveNotification() => IsReceiveNotification = false;
  public void RegisterReceiveNotification() => IsReceiveNotification = true;

  public void CreateEmptyOrder() => _orders.Add(new Entities.Orders.Order());

  public ShippingAddress AddShippingAddress(ShippingAddress address)
  {
    _addresses.Add(address);
    return address;
  }

  public void RemoveAddShippingAddress(int id)
  {
    var address = _addresses.FirstOrDefault(e => e.Id == id);

    if(address != null)
      address.Delete();
  }
}