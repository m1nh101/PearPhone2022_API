using Core.Entities.Phones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications;

public class PhoneStockSpecification : Specification<Stock>
{
  public PhoneStockSpecification(int id)
    : base(e => e.Id == id)
  {
    AddInclude(e => e.Include(d => d.Phone).ThenInclude(d => d.Sale)!);
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
    AddInclude(e => e.Include(d => d.Images));
  }
}