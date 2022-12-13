using Core.Entities.Orders;
using Core.Entities.Users;

namespace Core.Interfaces;

public interface ICheckout
{
  Task<string> Process(Order order, ShippingAddress address);
}
