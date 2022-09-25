using Core.Entities.Orders;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Stocks;

public class Phone : ModifierEntity
{
  /// <summary>
  /// get or set name of phone
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// get or set price of phone
  /// </summary>
  public double Price { get; set; }

  //navigation and foreign key
  private readonly List<Image> _images = new();
  public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

  /// <summary>
  /// get or set sale id
  /// </summary>
  public int SaleId { get; set; }
  public virtual Sale? Sale { get; set; }

  public virtual ICollection<Stock>? Stocks { get; set; }

  public int BranchId { get; set; }
  public virtual Branch? Branch { get; set; }

  public virtual ICollection<Item>? Items { get; set; }
}