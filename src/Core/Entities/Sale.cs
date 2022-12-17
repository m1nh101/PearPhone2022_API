using Core.Entities.Phones;
using Core.Exceptions;
using Shared.Bases;
using Shared.Enums;

namespace Core.Entities;

public class Sale : ModifierEntity
{
  private Sale() {}
  
  public Sale(DateTime effective, DateTime expired, int discount)
  {
    if(effective >= expired) // check effective date is later than expired date
      throw new InvalidTimeExeption("ngày hiệu lực không thể sau ngày kết thúc");
  
    if(discount > 100 || discount <= 0)
      throw new InvalidNumberException("giá trị phải nằm trong khoảng 1 - 100");
  
    Effective = effective;
    Expired = expired;
    Discount = discount;
  }

  /// <summary>
  /// get or set effective date
  /// </summary>
  public DateTime Effective { get; private set; }

  /// <summary>
  /// get or set expired date
  /// </summary>
  public DateTime Expired { get; private set; }

  /// <summary>
  /// get or set discount
  /// </summary>
  /// <value>valid in range 1 - 100</value>
  public int Discount { get; private set; }

  /// <summary>
  /// get or set status of sale
  /// </summary>
  public Status Status { get; private set; } = Status.None;

  public ICollection<Phone>? Phones { get; private set; }

  public void Update(Sale sale)
  {
    Effective = sale.Effective;
    Expired = sale.Expired;
    Discount = sale.Discount;
  }

  public void Delete() => Status = Status.Inactive;
}