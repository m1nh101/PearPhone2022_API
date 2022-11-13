using Shared.Interfaces;

namespace Core.Entities.Phones;

public partial class Phone : IAggregateRoot
{
  public Phone WithStocks(IEnumerable<Stock> stocks)
  {
    _stocks.AddRange(stocks);
    return this;
  }

  public Phone WithImages(IEnumerable<Image> images)
  {
    _images.AddRange(images);
    return this;
  }
  public Phone WithImages(IEnumerable<string> images)
  {
      _images.AddRange(images.Select(c=> new Image(c)));
      return this;
  }
}