using Core.Entities.Users;

namespace Core.Entities.Orders;

public partial class Order
{
  /// <summary>
  /// get userId that own this order
  /// </summary>
  public string UserId { get; private set; } = string.Empty;
  public virtual User? User { get; private set; }

  private readonly List<Item> _items = new();

  /// <summary>
  /// get list item in order
  /// </summary>
  public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

  public virtual Receipt? Receipt { get; set; }
}
