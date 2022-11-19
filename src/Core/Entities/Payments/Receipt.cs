using Core.Entities.Orders;
using Core.Entities.Users;
using Core.Exceptions;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Payments;

public class Receipt : ModifierEntity
{
  /// <summary>
  /// get or set user who sell product
  /// </summary>
  public string Seller { get; set; } = string.Empty;
  public double Total { get; private set; }

  /// <summary>
  /// get or set of receipt
  /// </summary>
  public Status Status { get; set; } = Status.None;

  /// <summary>
  /// get or set description for receipt
  /// </summary>
  public string Description { get; set; } = string.Empty;

  //navigation and foreign key
  public int OrderId { get; set; }
  public virtual Order? Order { get; set; }

  /// <summary>
  /// get or set shipping address id
  /// </summary>
  public int AddressId { get; set; }
  public virtual ShippingAddress? Address { get; set; }

  public int VoucherId { get; private set; }
  public virtual Voucher? Voucher { get; private set; }

  public void ApplyVoucher(Voucher voucher)
  {
    Voucher.Validate(voucher);

    if(voucher.VoucherType == VoucherType.Percent)
    {
      var discount = Total * voucher.Value;

      if(discount > voucher.MaxDiscount)
        Total -= voucher.MaxDiscount;
      else
        Total -= discount;
    }
    else
      Total -= voucher.MaxDiscount;
    
    Voucher = voucher;
  }
}