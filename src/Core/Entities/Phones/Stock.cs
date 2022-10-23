using Core.Entities.Orders;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Phones;

public partial class Stock : ModifierEntity
{
  /// <summary>
  /// get or set quantity of product in stock
  /// </summary>
  public int Quantity { get; private set; }

  public double Price { get; private set; }

  public Status Status { get; private set; } = Status.None;

  /// <summary>
  /// get or set phone id
  /// </summary>
  public int PhoneId { get; set; }
  public virtual Phone Phone { get; private set; } = null!;
  
  /// <summary>
  /// get or set phone detail id
  /// </summary>
  public int PhoneDetailId { get; set; }
  public virtual PhoneDetail? Detail { get; set; }

  /// <summary>
  /// get or set color id
  /// </summary>
  public int ColorId { get; set; }
  public virtual Color? Color { get; set; }

  public virtual ICollection<Item> Items { get; private set; } = null!;
}
