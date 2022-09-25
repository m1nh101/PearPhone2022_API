using Core.Entities.Stocks;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities;

public class Sale : ModifierEntity
{
  /// <summary>
  /// get or set effective date
  /// </summary>
  public DateTime Effective { get; set; }

  /// <summary>
  /// get or set expired date
  /// </summary>
  public DateTime Expired { get; set; }

  /// <summary>
  /// get or set discount
  /// </summary>
  /// <value>valid in range 0 - 1</value>
  public double Discount { get; set; }

  /// <summary>
  /// get or set status of sale
  /// </summary>
  public Status Status { get; set; } = Status.None;

  public ICollection<Phone>? Phones { get; set; }
}
