using Shared.Bases;
using Shared.Enums;

namespace Core.Entities.Phones;

public class IMEI : Entity
{
  private IMEI() {}
  public IMEI(string value)
  {
    Value = value;
  }

  public string Value { get; private set; } = string.Empty;
  public Status Status { get; private set; } = Status.Active;

  public virtual Stock? Stock { get; private set; }
  public int StockId { get; private set; }
}