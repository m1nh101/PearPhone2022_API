using Core.Entities.Payments;
using Core.Interfaces;

namespace Core.CQRS.Vouchers.Specs;

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
