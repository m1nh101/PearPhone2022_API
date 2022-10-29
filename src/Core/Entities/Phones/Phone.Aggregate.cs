using Shared.Interfaces;

namespace Core.Entities.Phones;

public partial class Phone : IAggregateRoot
{
  public Phone AddStock(IEnumerable<Stock> stocks)
  {
    return this;
  }

  public Phone AddImage(IEnumerable<Image> images)
  {
    return this;
  }
}