using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Cart.Specification;

public class GetCurrentOrderSpecification : Interfaces.Specification<Order>
{
  public GetCurrentOrderSpecification(string id)
    :base(e => e.UserId == id)
  {
    AddInclude(e => e.Include(d => d.Items)
      .ThenInclude(d => d.Stock)
      .ThenInclude(d => d.Phone)
      .ThenInclude(d => d.Images.First()));

    SetOrderBy(d => d.UpdatedAt);
  }
}