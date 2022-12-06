using Core.Entities.Orders;

namespace Core.Interfaces;

public interface ICheckout
{
  Task<string> Process(Order order);
}
