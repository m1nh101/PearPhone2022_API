namespace Core.Entities.Stocks;

public partial class Stock
{
  /// <summary>
  /// get or set phone id
  /// </summary>
  public int PhoneId { get; set; }
  public virtual Phone? Phone { get; set; }
  
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
}