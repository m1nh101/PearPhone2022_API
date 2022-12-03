using System.Diagnostics.CodeAnalysis;
using Core.Entities.Payments;

namespace Core.Comparers;

public class VoucherComparer : IEqualityComparer<Voucher>
{
  public bool Equals(Voucher? x, Voucher? y)
  {
    if(x == null && y == null)
      return true;
    else if (x == null || y == null)
      return false;
    else if (x.Code == y.Code && x.VoucherType == y.VoucherType)
      return true;
    else
      return false;
  }

  public int GetHashCode([DisallowNull] Voucher obj)
  {
    var hashCode = obj.Code.GetHashCode() ^ (int) obj.VoucherType;
    return hashCode.GetHashCode();
  }
}
