using Core.Entities.Orders;

namespace Core.Entities.Users;

public partial class User
{
  private readonly List<ShippingAddress> _addresses = new();
  public IReadOnlyCollection<ShippingAddress> Addresses => _addresses.AsReadOnly();

  private readonly List<Order> _orders = new();
  public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
}