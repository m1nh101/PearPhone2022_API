using Core.Entities.Orders;
using Core.Exceptions;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Phones;

public partial class Stock : ModifierEntity
{
  private Stock() { }

  public Stock(int quantity, double price, int capacity, int colorId, int detailId)
  {
    if(quantity < 0)
      throw new InvalidNumberException("Số lượng không thể nhỏ hơn 0");

    if(price < 0)
      throw new InvalidNumberException("Giá tiền không thể nhỏ hơn 0");

    if(capacity < 0)
      throw new InvalidNumberException("Dung lượng bộ nhớ không thể nhỏ hơn 0");

    Quantity = quantity;
    Price = price;
    Capacity = capacity;
    Status = Status.Active;
    ColorId = colorId;
    PhoneDetailId = detailId;
  }

  public Stock(int quantity, double price, int capacity, Color color, PhoneDetail detail)
  {
    if(quantity < 0)
      throw new InvalidNumberException("Số lượng không thể nhỏ hơn 0");

    if(price < 0)
      throw new InvalidNumberException("Giá tiền không thể nhỏ hơn 0");

    if(capacity < 0)
      throw new InvalidNumberException("Dung lượng bộ nhớ không thể nhỏ hơn 0");

    if(color == null)
      throw new ArgumentNullException(nameof(color), "Màu của sản phẩm không được trống");

    if(detail == null)
      throw new ArgumentNullException(nameof(detail), "Chi tiết sản phẩm không được trống");

    Quantity = quantity;
    Price = price;
    Color = color;
    Capacity = capacity;
    Status = Status.Active;
    Detail = detail;
  }

  /// <summary>
  /// get or set quantity of product in stock
  /// </summary>
  public int Quantity { get; private set; }

  public double Price { get; private set; }

  public Status Status { get; private set; } = Status.None;

  public int Capacity { get; private set; }

  /// <summary>
  /// get or set phone id
  /// </summary>
  public int PhoneId { get; private set; }
  public virtual Phone Phone { get; private set; } = null!;

  /// <summary>
  /// get or set phone detail id
  /// </summary>
  public int PhoneDetailId { get; private set; }
  public virtual PhoneDetail? Detail { get; private set; }

  /// <summary>
  /// get or set color id
  /// </summary>
  public int ColorId { get; private set; }
  public virtual Color? Color { get; private set; }

  public virtual ICollection<Item> Items { get; private set; } = null!;

  public int ReduceQuantity(int value)
  {
    if (value <= 0)
      throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be negative");

    if (value > Quantity)
      throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be greater than current quantity");

    Quantity -= value;

    return Quantity;
  }

  public int IncreaseQuantity(int value)
  {
    if (value <= 0)
      throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be negative");

    Quantity += value;

    return Quantity;
  }
}