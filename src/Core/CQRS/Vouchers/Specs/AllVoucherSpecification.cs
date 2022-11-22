using Core.Entities.Payments;
using Core.Interfaces;

namespace Core.CQRS.Vouchers.Specs;

public class AllVoucherSpecification : Specification<Voucher>
{
  public AllVoucherSpecification()
    : base(x => x.Status != Shared.Enums.Status.None)
  {
  }
}