using Core.Entities.Payments;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications;

public sealed class ReceiptSpecification : Specification<Receipt>
{
  public ReceiptSpecification(int orderId)
    :base(e => e.Status != Shared.Enums.Status.Done && e.OrderId == orderId)
  {
    AddInclude(e => e.Include(d => d.Order).ThenInclude(d => d.Items));
    AddInclude(e => e.Include(d => d.Voucher));
  }
}
