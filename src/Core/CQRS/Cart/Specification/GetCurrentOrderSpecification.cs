using Core.Entities.Orders;

namespace Core.CQRS.Cart.Specification;

public class GetCurrentOrderSpecification : Interfaces.Specification<Order>
{
  public GetCurrentOrderSpecification(string id)
    :base(e => e.UserId == id)
  {
    
  }
}