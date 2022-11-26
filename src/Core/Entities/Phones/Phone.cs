using Core.Entities.Orders;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Phones;

public partial class Phone : ModifierEntity
{
  private Phone() {}

  public Phone(string name, string branch)
  {
    if(string.IsNullOrEmpty(name))
      throw new ArgumentNullException(nameof(name), "Tên điện thoại không được trống");

    if(string.IsNullOrEmpty(branch))
      throw new ArgumentNullException(nameof(branch), "Tên hãng điện thoại không được trống");

    Name = name;
    Branch = branch;
    Status = Status.Active;
  }

  /// <summary>
  /// get or set name of phone
  /// </summary>
  public string Name { get; private set; } = string.Empty;
  public string Branch { get; private set; } = string.Empty;
  public Status Status { get; private set; }

  //navigation and foreign key
  private readonly List<Image> _images = new();
  public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

  /// <summary>
  /// get or set sale id
  /// </summary>
  public int? SaleId { get; private set; }
  public virtual Sale? Sale { get; private set; }

  public virtual ICollection<Item>? Items { get; set; }

  private readonly List<Stock> _stocks = new();
  public IReadOnlyCollection<Stock> Stocks => _stocks.AsReadOnly();
}