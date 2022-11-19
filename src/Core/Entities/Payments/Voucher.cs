using Shared.Bases;

namespace Core.Entities.Payments;

public class Voucher : ModifierEntity
{
  private Voucher() {}
  private Voucher(string code, DateTime effectiveDate, DateTime expiredDate,
    int timesRemain)
  {
    Code = code;
    EffectiveDate = effectiveDate;
    ExpiredDate = expiredDate;
    TimesRemain = timesRemain;
  }

  public string Code { get; private set; } = string.Empty;
  public DateTime EffectiveDate { get; private set; }
  public DateTime ExpiredDate { get; private set; }
  public int TimesRemain { get; private set; }

  public virtual ICollection<Receipt> Receipts { get; private set; } = null!;
}