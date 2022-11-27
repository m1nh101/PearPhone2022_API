using Core.Entities.Payments;
using Core.Interfaces;

namespace Core.Specifications;

public class AllVoucherSpecification : Specification<Voucher>
{
  public AllVoucherSpecification()
    : base(x => x.Status != Shared.Enums.Status.None)
  {
  }
}

public class VoucherDetailSpecification : Specification<Voucher>
{
  public VoucherDetailSpecification(int id)
    :base(x => x.Id == id)
  {
  }

  public VoucherDetailSpecification(string code)
    :base(x => x.Code == code)
  {
  }    
}