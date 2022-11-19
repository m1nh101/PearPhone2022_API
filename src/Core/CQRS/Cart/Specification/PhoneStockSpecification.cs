using System.Linq.Expressions;
using Core.Entities.Phones;

namespace Core.CQRS.Cart.Specification;

public class PhoneStockSpecification : Interfaces.Specification<Stock>
{
  public PhoneStockSpecification(int id)
    : base(e => e.PhoneId == id)
  {
  }
}