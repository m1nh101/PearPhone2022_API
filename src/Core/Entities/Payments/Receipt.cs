using Core.Entities.Orders;
using Core.Entities.Users;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Payments;

public class Receipt : ModifierEntity
{
  private Receipt() {}

  public Receipt(Order order)
  {
    Order = order;
  }

  public Receipt(Order order, string description)
  {
    Order = order;
    Description = description;
  }

  public Receipt WithShippingAddress(ShippingAddress shippingAddress)
  {
    Address = shippingAddress;
    return this;
  }

  public Receipt WithSeller(string id)
  {
    Seller = id ?? "Hệ thống";
    return this;
  }

  public Receipt WithTotalPrice(double total)
  {
    Total = total;
    return this;
  }

  /// <summary>
  /// get or set user who sell product
  /// </summary>
  public string Seller { get; set; } = string.Empty;
  public double Total { get; private set; }

  /// <summary>
  /// get or set of receipt
  /// </summary>
  public Status Status { get; private set; } = Status.Inprocess;

  /// <summary>
  /// get or set description for receipt
  /// </summary>
  public string Description { get; set; } = string.Empty;

  //navigation and foreign key
  public int OrderId { get; private set; }
  public virtual Order Order { get; private set; } = null!;

  /// <summary>
  /// get or set shipping address id
  /// </summary>
  public int AddressId { get; private set; }
  public virtual ShippingAddress Address { get; private set; } = null!;

  public int VoucherId { get; private set; }
  public virtual Voucher Voucher { get; private set; } = null!;

  public double ApplyVoucher(Voucher voucher)
  {
    Voucher.Validate(voucher);

    Voucher = voucher;

    if(voucher.VoucherType == VoucherType.Percent)
    {
      var discount = Total * voucher.Value;

      if(discount > voucher.MaxDiscount)
        Total -= voucher.MaxDiscount;
      else
      {
        Total -= discount;
        return discount;
      }
    }
    else
      Total -= voucher.MaxDiscount;
    
    voucher.ApplySucceed();
    
    return voucher.MaxDiscount;
  }

  public void CheckoutSucceed() => Status = Status.Done;
}