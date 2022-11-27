using Core.Entities.Orders;
using Core.Entities.Phones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications;

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

public class PhoneStockSpecification : Specification<Stock>
{
  public PhoneStockSpecification(int id)
    : base(e => e.PhoneId == id)
  {
  }
}

public class PhoneSpecification : Specification<Phone>
{
  public PhoneSpecification(int id)
    :base(e => e.Id == id)
  {
    AddInclude(e => e
      .Include(d => d.Stocks!)
      .ThenInclude(d => d.Color!)
      .ThenInclude(d => d.Images!));

    AddInclude(e => e.Include(d => d.Detail!));
  }
}