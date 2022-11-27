using Core.Exceptions;
using Core.Helpers;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Payments;

public class Voucher : ModifierEntity
{
  private Voucher() {}
  public Voucher(string name, DateTime effectiveDate, DateTime expiredDate,
    int timesRemain, VoucherType type)
  {
    if(string.IsNullOrEmpty(name))
      throw new ArgumentNullException(nameof(name), "tên không thể để trống");

    if(timesRemain <= 0)
      throw new InvalidNumberException($"số lần sử dụng là {timesRemain} không hợp lệ");

    if(expiredDate <= effectiveDate)
      throw new InvalidTimeExeption("ngày hiệu lực không thể sau ngày kết thúc");

    Name = name;
    EffectiveDate = effectiveDate;
    ExpiredDate = expiredDate;
    TimesRemain = timesRemain;
    VoucherType = type;
    Code = RandomCode.Generate();
  }
  public string Name { get; private set; } = string.Empty;
  public string Code { get; private set; } = string.Empty;
  public DateTime EffectiveDate { get; private set; }
  public DateTime ExpiredDate { get; private set; }
  public double MaxDiscount { get; private set; }
  public int TimesRemain { get; private set; }
  public double Value { get; private set; } // 
  public VoucherType VoucherType { get; private set; }
  public Status Status { get; private set; } = Status.Active;

  public virtual ICollection<Receipt> Receipts { get; private set; } = null!;

  public void Delete() => Status = Status.None;

  public Voucher Update(Voucher voucher)
  {
    ExpiredDate = voucher.ExpiredDate;
    EffectiveDate = voucher.EffectiveDate;
    TimesRemain = voucher.TimesRemain;
    VoucherType = voucher.VoucherType;
    Name = voucher.Name;

    return this;
  }

  public static void Validate(Voucher voucher)
  {
    if(voucher.TimesRemain == 0)
      throw new OutOfUseException($"{voucher.Code} đã hết lượt dùng");

    if(voucher.ExpiredDate < DateTime.Now)
      throw new VoucherExpiredException($"{voucher.Code} đã hết hạn sử dụng");

    if(voucher.EffectiveDate > DateTime.Now)
      throw new InvalidVoucherException($"{voucher.Code} không hợp lệ");
  }
}